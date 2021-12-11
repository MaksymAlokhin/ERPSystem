using System;
using Xunit;
using ERPSystem.Pages;
using ERPSystem.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ERPTest.Tests.UnitTests
{
    public class DataAccessLayerTest
    {
        [Fact]
        public async Task GetMessagesAsync_MessagesAreReturned()
        {
            using (var db = new ApplicationDbContext(Utilities.TestDbContextOptions()))
            {
                //// Arrange
                //var expectedMessages = ApplicationDbContext.GetSeedingMessages();
                //await db.AddRangeAsync(expectedMessages);
                //await db.SaveChangesAsync();

                //// Act
                //var result = await db.GetMessagesAsync();

                //// Assert
                //var actualMessages = Assert.IsAssignableFrom<List<Message>>(result);
                //Assert.Equal(
                //    expectedMessages.OrderBy(m => m.Id).Select(m => m.Text),
                //    actualMessages.OrderBy(m => m.Id).Select(m => m.Text));
            }
        }
    }
}
