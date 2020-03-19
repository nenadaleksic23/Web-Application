using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Validators
{
    public class ContainDigitAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string str = value as string;
            return !str.Where(m => Char.IsDigit(m)).Any();
        }
    }
}