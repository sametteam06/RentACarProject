using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DisplacementId).NotEmpty();
            //RuleFor(c => c.Description).Must(StartWithA).WithMessage("Açıklama A harfi ile başlamalı");
            RuleFor(c => c.ModelYear).GreaterThan(2010);
            RuleFor(c => c.Description.Length).LessThan(30);
            RuleFor(c => c.MinFindexPoint).GreaterThan(0);
            RuleFor(c => c.MinFindexPoint).LessThan(1900);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
