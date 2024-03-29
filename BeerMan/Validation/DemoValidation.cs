﻿using BeerMan.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerMan.Validation
{
    public class DemoValidation:AbstractValidator<DemoValid>
    {
        public DemoValidation()
        {
            RuleFor(r => r.num1).NotNull().WithMessage("Error");
            RuleFor(r => r.num2).GreaterThan(5).WithMessage("Error num>5").LessThan(100).WithMessage("Error num<100");
            RuleFor(r => r.num3).Must(num => num % 5 == 0).WithMessage("Error num % 5 !=0");

            RuleFor(r => r.str1).NotEmpty().WithMessage("Error");
            RuleFor(r => r.str2).MaximumLength(10).WithMessage("Error");
            RuleFor(r => r.str3).Must(str => str.Contains("vxcvxvx")).WithMessage("Error");

            RuleFor(r => r.DateTime1).NotNull().WithMessage("Error");
            RuleFor(r => r.DateTime2).InclusiveBetween(new DateTime(2001, 1, 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            RuleFor(r => r.DateTime3).Must(date => date.DayOfWeek == DayOfWeek.Tuesday).WithMessage("Error");

            RuleFor(r => r.bool1).NotNull().WithMessage("Error");
            RuleFor(r => r.bool2).Equal(true).WithMessage("Error");
            RuleFor(r => r.bool3).Must(b => b == false).WithMessage("Error");

        }
    }
}