using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).Must(IsUpperCase).WithMessage("İsim büyük harfle başlamalı ");
            RuleFor(u=>u.Email).Must(IsTrueFormat).WithMessage("E posta @gmail.com ile bitmeli");
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).MinimumLength(8);
        }

        private bool IsTrueFormat(string arg)
        {
            return arg.EndsWith("@gmail.com");
        }

        private bool IsUpperCase(string arg)
        {
            return (arg[0]>=65&&arg[0]<=90);
        }
    }
}
