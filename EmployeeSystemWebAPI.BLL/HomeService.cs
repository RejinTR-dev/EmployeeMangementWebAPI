

namespace EmployeeSystemWebAPI.BLL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EmployeeSystemWebAP.DAL;
    using EmployeeSystemWebAPI.Model;

    public class HomeService : IHomeService
    {
        /// <summary>
        /// Gets IHomeDA.
        /// </summary>
        private readonly IHomeDA homeDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeService" /> class.
        /// </summary>
        /// <param name="homeDA">Home DA.</param>
        public HomeService(IHomeDA homeDA)
        {
            this.homeDA = homeDA;
        }

        public OutPutModel SaveEmployeeDetails(EmployeeDetails employeeDetails)
        {
            return this.homeDA.SaveEmployeeDetails(employeeDetails);
        }

        public List<RoleAccess> GetRoleAccessCheck(string email, string password)
        {
                List<RoleAccess> roleList = new List<RoleAccess>();

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    roleList = this.homeDA.RoleAccessCheck(email, password);
                    if (roleList?.Count > 0)
                    {
                        return roleList;
                    }
                }
                else
                {
                    roleList = null;
                }

            return roleList;
           
        }

        //public List<RoleAccess> GetRoleAccessCheck(string email, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
