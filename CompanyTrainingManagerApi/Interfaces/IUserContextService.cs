using CompanyTrainingManagerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Interfaces
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get;  }
        int? UserId { get;  }
    }
}
