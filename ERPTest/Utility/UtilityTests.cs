using ERPSystem;
using ERPSystem.Data;
using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UtilityTest
{
    public class UtilityTests
    {
        public ApplicationDbContext context { get; private set; }

        public static readonly object[][] Dates =
            {
                new object[] { new DateTime(2020,3,3), new DateTime(2021,3,4)},
                new object[] { new DateTime(2022,2,28), new DateTime(2022,3,1)},
                new object[] { new DateTime(1,8,13), new DateTime(3333,10,14)},
            };

        [Theory, MemberData(nameof(Dates))]
        public void Utility_GetRandomDate_ReturnsDateBetween_WhenEndDateIsGreaterThanStartDate(DateTime startDate, DateTime endDate)
        {
            //Arrange

            //Act
            DateTime actualDate = Utility.GetRandomDate(startDate, endDate);

            //Assert
            Assert.True(actualDate >= startDate && actualDate <= endDate);
        }
        public static readonly object[][] BackwardsDates =
            {
                new object[] { new DateTime(2021, 3, 4), new DateTime(2020,3,3)},
                new object[] { new DateTime(2022, 3, 1), new DateTime(2022,2,28)},
                new object[] { new DateTime(3333, 10, 14), new DateTime(1,8,13)}
            };

        [Theory, MemberData(nameof(BackwardsDates))]
        public void Utility_GetRandomDate_ReturnsDateBetween_WhenEndDateIsLessThanStartDate(DateTime startDate, DateTime endDate)
        {
            //Arrange

            //Act
            DateTime actualDate = Utility.GetRandomDate(startDate, endDate);

            //Assert
            Assert.True(actualDate <= startDate && actualDate >= endDate);
        }
        public static readonly object[][] BusinessDates =
            {
                new object[] { new DateTime(2021,12,15), new DateTime(2021,12,18), 3.0},
                new object[] { new DateTime(2021,12,16), new DateTime(2021,12,19), 2.0},
                new object[] { new DateTime(2021,12,17), new DateTime(2021,12,20), 2.0},
                new object[] { new DateTime(2021,12,18), new DateTime(2021,12,21), 2.0},
                new object[] { new DateTime(2021,12,19), new DateTime(2021,12,22), 3.0},
                new object[] { new DateTime(2021,12,20), new DateTime(2021,12,23), 4.0},
            };

        [Theory, MemberData(nameof(BusinessDates))]
        public void Utility_GetBusinessDays_ReturnsNumberOfBusinessDaysBetweenDates_WhenEndDateIsGreaterThanStartDate(DateTime startDate, DateTime endDate, int expectedDays)
        {
            //Arrange

            //Act
            double actualDays = Utility.GetBusinessDays(startDate, endDate);

            //Assert
            Assert.Equal(expectedDays, actualDays);
        }
        public static readonly object[][] BackwardsBusinessDates =
            {
                new object[] { new DateTime(2021, 12, 18), new DateTime(2021,12,15), 3.0},
                new object[] { new DateTime(2021, 12, 19), new DateTime(2021,12,16), 2.0},
                new object[] { new DateTime(2021, 12, 20), new DateTime(2021,12,17), 2.0},
                new object[] { new DateTime(2021, 12, 21), new DateTime(2021,12,18), 2.0},
                new object[] { new DateTime(2021, 12, 22), new DateTime(2021,12,19), 3.0},
                new object[] { new DateTime(2021, 12, 23), new DateTime(2021,12,20), 4.0},
            };

        [Theory, MemberData(nameof(BackwardsBusinessDates))]
        public void Utility_GetBusinessDays_ReturnsNumberOfBusinessDaysBetweenDates_WhenEndDateIsLessThanStartDate(DateTime startDate, DateTime endDate, int expectedDays)
        {
            //Arrange

            //Act
            double actualDays = Utility.GetBusinessDays(startDate, endDate);

            //Assert
            Assert.Equal(expectedDays, actualDays);
        }
    }
}
