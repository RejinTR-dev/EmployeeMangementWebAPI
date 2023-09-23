using Microsoft.AspNetCore.Authorization;

namespace EmployeeSystemWebAPI.Authentication
{
    public static class AccessStore
    {
        // public static List<string> AllowedServiceAccounts { get; set; }

        public static string EmployeeAccountName { get; set; }

        public static AuthorizationHandlerContext AuthorizationHandlerContext { get; set; }
        public static List<string> AllowedEmployeeAccounts = new List<string> { };
    }
}
