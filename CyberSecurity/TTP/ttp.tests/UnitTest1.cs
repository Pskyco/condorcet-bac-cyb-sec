using System.IO;
using System.Threading.Tasks;
using medical_data.Entities;
using medical_data.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ttp.tests
{
    public class Tests
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void Setup()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyBlogDb")
                .Options;
        }

        [Test]
        public async Task Test1()
        {
            // Arrange
            var blogContext = new ApplicationDbContext(dbContextOptions);
            blogContext.Add(new Participant()
            {
                HasEverDrank = true,
                HasEverSmoked = true,
                Height = 245.6m,
                Weight = 124.5m,
                Id = 1,
                StudyCode = "BE-000001"
            });
            blogContext.Add(new Participant()
            {
                HasEverDrank = true,
                HasEverSmoked = true,
                Height = 245.6m,
                Weight = 124.5m,
                Id = 2,
                StudyCode = "BE-000002"
            });
            blogContext.Add(new Participant()
            {
                HasEverDrank = true,
                HasEverSmoked = true,
                Height = 245.6m,
                Weight = 124.5m,
                Id = 3,
                StudyCode = "BE-000003"
            });

            // Act
            await blogContext.SaveChangesAsync();

        
            // Assert
            Assert.AreEqual(3, await blogContext.Set<Participant>().CountAsync());
        }
    }
}