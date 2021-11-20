using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem
{
    public class Utility
    {
        public static DateTime GetRandomDate(int Start, int End)
        {
            var random = new Random();
            var startDate = DateTime.Now.AddYears(Start);
            var endDate = DateTime.Now.AddYears(End);
            var range = Convert.ToInt32(endDate.Subtract(startDate).TotalDays);
            return startDate.AddDays(random.Next(range));
        }
    }
}
