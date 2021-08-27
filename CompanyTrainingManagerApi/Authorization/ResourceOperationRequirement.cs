using CompanyTrainingManagerApi.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Authorization
{
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {

        public ResourceOperationRequirement(ResourceOperation operation)
        {
            Operation = operation;
        }

        public ResourceOperation Operation { get; }
    }
}
