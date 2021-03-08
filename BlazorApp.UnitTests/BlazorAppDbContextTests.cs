using NUnit.Framework;
using System.Threading.Tasks;

namespace BlazorApp.UnitTests
{    
    public class BlazorAppDbContextTests : MemoryDbContext
    {
        [Test]
        public async Task DatabaseIsAvailableTest()
        {
            Assert.True(await _context.Database.CanConnectAsync());
        }
    }
}
