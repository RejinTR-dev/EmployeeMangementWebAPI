using Microsoft.AspNetCore.Authorization;

namespace EmployeeSystemWebAPI.Authentication
{
    public class ShouldbeAuthorizedAppRequirement
         : IAuthorizationRequirement
    {
    }

    public class ShouldbeAuthorizedAppRequirementHandler
        : AuthorizationHandler<ShouldbeAuthorizedAppRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ShouldbeAuthorizedAppRequirement requirement)
        {
            var identity_var = context.User.Identity.Name.ToLower();

            if (AccessStore.AllowedEmployeeAccounts.Contains(identity_var))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }

}
