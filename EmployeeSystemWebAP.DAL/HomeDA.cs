

namespace EmployeeSystemWebAP.DAL
{
    using EmployeeSystemWebAPI.Model;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    public class HomeDA : IHomeDA
    {
        private readonly EmployeeDetails employee;
        //public HomeDA(IConfiguration configuration)
        //{
        //    employee.Emai_ID = "abc@123.com";
        //}

        /// <summary>
        /// Object for Http Context Accessor
        /// </summary>
        private readonly IHttpContextAccessor contextAccessor;

        /// <summary>
        /// MethodName.
        /// </summary>
        /// <param name="memberName">member Name.</param>
        /// <returns>member name.</returns>
        public string MethodName(
       [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            return memberName;
        }

        /// <summary>
        /// StartClock.
        /// </summary>
        /// <returns>clock.</returns>
        public Stopwatch StartClock()
        {
            return Stopwatch.StartNew();
        }

        /// <summary>
        /// StopClock.
        /// </summary>
        /// <param name="watch">watch.</param>
        /// <param name="methodName">method Name.</param>
        /// <param name="controllerName">controller Name.</param>
        public void StopClock(Stopwatch watch, string methodName, string controllerName)
        {
            watch.Stop();
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, controllerName + ".txt");
            string createText = "Method : " + methodName;
            createText = createText + Environment.NewLine + "Execution Time : " + watch.Elapsed.Milliseconds + Environment.NewLine;
            File.AppendAllText(destPath, createText);
        }

        /// <summary>
        /// <summary>
        /// Save Submit Actions
        /// </summary>
        /// <param name="submitActionsModel"> Submit Actions</param>
        /// <returns>Status of the save, error model</returns>
        public OutPutModel SaveEmployeeDetails(EmployeeDetails employeeDetails)
        {
            //HttpContext httpContext;
            OutPutModel saveEmployeeDetailsOutput = new OutPutModel();

            //if (employeeDetails != null)
            //{
            //    // update dashGridData here
            //    string json = JsonConvert.SerializeObject(employeeDetails);
            //    //httpContext.Session.Remove("EmployeeDetails");
            //    httpContext.Session.SetString("EmployeeDetails", string.Empty);
            //    httpContext.Session.SetString("EmployeeDetails", json);
            //    saveEmployeeDetailsOutput.message = "Success";
            //}
            //else
            //{
            //    saveEmployeeDetailsOutput.message = "Failed";
            //}
            
            saveEmployeeDetailsOutput = GetGridDetails(this.contextAccessor.HttpContext, employeeDetails);

            return saveEmployeeDetailsOutput;
        }

        public List<RoleAccess> RoleAccessCheck(string email, string password)
        {
            HttpContext? httpContext = null;
            List<EmployeeDetails>? resultData = null;
            try
            {
                RoleAccess roleAccess = new RoleAccess();
                List<RoleAccess> roleTypes = new List<RoleAccess>();
                string storedValue = httpContext.Session.GetString("EmployeeDetails").ToString();
                if (!string.IsNullOrEmpty(storedValue))
                {
                    resultData = JsonConvert.DeserializeObject<List<EmployeeDetails>>(storedValue);
                }
                else
                {
                    resultData = null;
                }

                var result = from f in resultData
                             where f.Emai_ID == email
                             where f.PassWord == password
                             select f;
                if (result != null)
                {
                    var admincheck = from j in result
                                     where j.Emai_ID == "abc@123.com"
                                 select j;
                    if (admincheck != null)
                    {
                        roleAccess.PrivillageNameId = 1;
                        roleAccess.PrivillageName = "Admin";
                    }
                    else
                    {
                        roleAccess.PrivillageNameId = 2;
                        roleAccess.PrivillageName = "Others";
                    }
                }
                else
                {
                    roleAccess.PrivillageNameId = 0;
                    roleAccess.PrivillageName = "UnAuthorized";
                }

                roleTypes= JsonConvert.DeserializeObject<List<RoleAccess>>(roleAccess.ToString());

                return roleTypes;
            }
            catch (SystemException)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static OutPutModel GetGridDetails(HttpContext httpContext, EmployeeDetails employeeDetails)
        {
            try
            {
                OutPutModel saveEmployeeDetailsOutput = new OutPutModel();

                if (employeeDetails != null)
                {
                    string json = JsonConvert.SerializeObject(employeeDetails);
                    httpContext.Session.Remove("EmployeeDetails");
                    httpContext.Session.SetString("EmployeeDetails", string.Empty);
                    httpContext.Session.SetString("EmployeeDetails", json);
                    saveEmployeeDetailsOutput.message = "Success";
                }
                else
                {
                    saveEmployeeDetailsOutput.message = "Failed";
                }
                return saveEmployeeDetailsOutput;
            }
            catch (SystemException ex)
            {
                throw new SystemException("Exception occured", ex);
            }
           
        }
    }
}
