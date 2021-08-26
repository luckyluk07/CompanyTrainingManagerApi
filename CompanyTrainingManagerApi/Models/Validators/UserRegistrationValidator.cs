using CompanyTrainingManagerApi.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Models.Validators
{
    public class UserRegistrationValidator : AbstractValidator<RegisterAccountDto>
    {
        public UserRegistrationValidator(AppDbContext dbContext)
        {
            RuleFor(a => a.Password).MinimumLength(4).NotEmpty();
            RuleFor(a => a.PasswordConfirmation).Equal(a => a.Password);

            RuleFor(a => a.Email).EmailAddress().Custom((email, context) =>
            {
                var emailExist = dbContext.Users.Any(u => u.Email == email);
                if(emailExist == true)
                {
                    context.AddFailure("Account with this email already exist");
                }
            });

        }
    }
}
