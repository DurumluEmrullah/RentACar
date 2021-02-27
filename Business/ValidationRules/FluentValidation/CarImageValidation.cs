using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidation:AbstractValidator<CarImage>
    {
        public CarImageValidation()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.ImagePath).NotEmpty();
            RuleFor(c => c.ImagePath).Must(ExtensionRules)
                .WithMessage("Yüklediğiniz dosya .jpeg .jpg .png uzantılarından birine sahip olmalıdır");
        }

        private bool ExtensionRules(string arg)
        {
            return arg.Substring(arg.LastIndexOf(".")).ToLower().Equals(".jpeg") || arg.Substring(arg.LastIndexOf(".")).ToLower().Equals(".png") || arg.Substring(arg.LastIndexOf(".")).ToLower().Equals(".jpg");
        }
    }
}
