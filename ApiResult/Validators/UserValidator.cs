using ApiResult.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiResult.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Empty()
                .EmailAddress();

            RuleFor(u => u.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must((user, name) => CheckUnique(user));
        }

        private bool CheckUnique(User user)
        {
            //logika sprawdzania unikalności nazway tak dla przykłądu

            return true;
        }
    }
}