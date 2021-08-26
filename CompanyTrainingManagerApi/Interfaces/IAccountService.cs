using CompanyTrainingManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Interfaces
{
    public interface IAccountService
    {
        void RegisterUser(RegisterAccountDto dto);
    }
}
