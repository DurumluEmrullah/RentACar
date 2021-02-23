using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
        
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(1975).When(c=>c.DailyPrice>=400);
            RuleFor(c => c.CarName).MinimumLength(3);
        }
    }
}
