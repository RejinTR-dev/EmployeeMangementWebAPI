using Azure.Core;
using EmployeeSystemWebAP.DAL;
using EmployeeSystemWebAPI.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeSystemWebAPI.Extension
{
    public static class ServiceExtensions
    {

        /// <summary>
        /// Provide Application DA Collections
        /// </summary>
        /// <param name="ser">IService Collection</param>
        public static void ProvideApplicationDA(this IServiceCollection ser)
        {
           
            ser.AddScoped(typeof(IHomeDA), typeof(HomeDA));
            
        }

        /// <summary>
        /// Provide Application Services
        /// </summary>
        /// <param name="ser">IService Collection</param>
        public static void ProvideApplicationServices(this IServiceCollection ser)
        {
            ser.AddScoped(typeof(IHomeService), typeof(HomeService));
        }

        
    }
}
