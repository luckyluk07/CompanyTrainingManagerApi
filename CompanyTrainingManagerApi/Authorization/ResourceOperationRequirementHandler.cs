using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Worker>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Worker worker)
        {
            //if(requirement.Operation == ResourceOperation.Create)
            //{
            //    context.Fail();
            //}

            var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role).Value;

            if (role == "HrManager" || role == "Admin")
            {
                context.Succeed(requirement);
            }

            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if(worker.IsAUserId == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
