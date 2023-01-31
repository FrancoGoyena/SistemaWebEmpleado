using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Validations
{
    public class CheckValidYearAttribute:ValidationAttribute
    {
        public CheckValidYearAttribute()
        {
            ErrorMessage = "El año debe ser mayor o igual a 2000";
        }
        public override bool IsValid(object value)
        {
            int year = Convert.ToDateTime(value).Year;
            if (year < 2000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
