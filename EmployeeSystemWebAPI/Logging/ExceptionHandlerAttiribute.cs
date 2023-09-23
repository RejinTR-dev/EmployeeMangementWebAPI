using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeSystemWebAPI.Logging
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
       

        /// <summary>
        /// Gets or set config 
        /// </summary>
        private readonly IConfiguration config;


        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlerAttribute" /> class
        /// </summary>
        /// <param name="appDynamics">Dynamics as parameter</param>
        /// <param name="config">config as parameter</param>
        public ExceptionHandlerAttribute(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// OnException method
        /// </summary>
        /// <param name="context">context as parameter</param>
        public override void OnException(ExceptionContext context)
        {
            IActionResult result;
            var exceptionType = context.Exception.GetType();
            var message = context.Exception.Message;
            var stackTrace = context.Exception.StackTrace;
            var target = context.Exception.TargetSite;
            var source = context.Exception.Source;
            var innerexceptionmessage = context.Exception.InnerException;

            if (exceptionType == typeof(Exception))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                if (!Convert.ToBoolean(this.config["EmployeeConfigValues:SeeError"]))
                {
                    message = "Server error occured, retry after sometime !";
                }
                result = new JsonResult($"Error: {message}," +
                  $"StackTrace: {context?.Exception?.StackTrace}," +
                  $"Source: {context?.Exception?.Source}," +
                  $"InnerException: {context?.Exception?.InnerException?.Message}");
                context.Result = result;
            }
            // ------------- log the context--- 
            //just write
            Console.WriteLine(context.Result);
            //-----------
        }
    }
}
