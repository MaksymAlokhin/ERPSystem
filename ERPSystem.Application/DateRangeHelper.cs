using System;

namespace ERPSystem.Application
{
    // Pure date-math helpers with no external dependencies, so they stay
    // plain static methods rather than an injected service.
    public static class DateRangeHelper
    {
        public static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                var dates = SwapDates(startDate, endDate);
                startDate = dates[0];
                endDate = dates[1];
            }
            var random = new Random();
            var range = Convert.ToInt32(endDate.Subtract(startDate).TotalDays);
            return startDate.AddDays(random.Next(range));
        }

        public static double GetBusinessDays(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                var dates = SwapDates(startDate, endDate);
                startDate = dates[0];
                endDate = dates[1];
            }

            double calcBusinessDays =
                1 + ((endDate - startDate).TotalDays * 5 -
                (startDate.DayOfWeek - endDate.DayOfWeek) * 2) / 7;

            if (endDate.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startDate.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
        }

        public static DateTime[] SwapDates(DateTime one, DateTime two)
        {
            var temp = one;
            one = two;
            two = temp;
            return new DateTime[] { one, two };
        }
    }
}
