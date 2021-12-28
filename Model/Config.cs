using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public static class Config
    {
        public const byte MONTH_WORKING_HOURS_ALLOWED = 160;
        public const byte DAY_WORKING_HOURS_ALLOWED = 8;
        public const decimal SUPERVISOR_MONTH_SALARY = 2700;
        public const decimal SUPERVISOR_MONTH_BONUS = 270;
        public const decimal LOCAL_EMPLOYEE_MONTH_SALARY = 1500;
    }
}
