using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystemWebAPI.Controllers
{
    using EmployeeSystemWebAPI.BLL;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using EmployeeSystemWebAPI.Model;
    using EmployeeSystemWebAPI.Logging;



    /// <summary>
    /// Home Controller
    /// </summary>
  
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[Authorize(Policy = "ShouldbeAuthorizedApp")]
    [TypeFilter(typeof(ExceptionHandlerAttribute))]
    public class HomeController : ControllerBase
        {
            #region Private Variables
            /// <summary>
            /// Gets IHomeService
            /// </summary>
            private readonly IHomeService homeService;


        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class
        /// </summary>
        /// <param name="homeService">home Service</param>
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;

        }


        [HttpGet("GetRoleAccessCheck")]
        public JsonResult GetRoleAccessCheck(string email,string password)
        {

                if (ModelState.IsValid)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return new JsonResult(this.homeService.GetRoleAccessCheck(email, password));
                    //return new JsonResult(ModelState);
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    return new JsonResult(ModelState);
                }
        }

        //[HttpGet("rolecheck")]
        //public JsonResult rolecheck()
        //{
        //    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        //    return new JsonResult("asdc");
        //}

        [HttpPost("SaveEmployeeDetails")]
        public JsonResult SaveEmployeeDetails(EmployeeDetails employeeDetails)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return new JsonResult(this.homeService.SaveEmployeeDetails(employeeDetails));
            //return new JsonResult(Response.StatusCode);
        }



        #region public methods
        /// <summary>
        /// Get Dash Board Tiles Details
        /// </summary>
        /// <param name="associateID">Associate ID</param>
        /// <param name="assignedGroupId">assignedGroupId</param>
        /// <returns>Dash Board  tiles object</returns>
        //[HttpGet("GetDashBoardTiles")]
        //public JsonResult GetDashBoardTiles(string associateID, int assignedGroupId)
        //{
        //    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        //    return new JsonResult(this.homeService.GetDashBoardTiles(XSS.HtmlEncode(associateID), assignedGroupId));
        //}

        /// <summary>
        /// Get Dash Grid Details
        /// </summary>
        /// <param name="dashBoard">dash Board</param>
        /// <returns>Dash Grid Details as Result</returns>
        //[HttpPost("GetDashGridDetails")]
        //public JsonResult GetDashGridDetails(DashBoard dashBoard)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        //        return new JsonResult(this.homeService.GetDashGridDetails(dashBoard));
        //    }
        //    else
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        //        return new JsonResult(ModelState);
        //    }
        //}
        #endregion
    }
}
