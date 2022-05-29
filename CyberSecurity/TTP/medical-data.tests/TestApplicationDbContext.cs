using System;
using System.Threading.Tasks;
using medical_data.Entities;
using medical_data.Persistence;
using medical_data.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace medical_data.tests
{
    public class TestApplicationDbContext
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyUnitTestDatabase")
                .Options;

            Console.WriteLine("I'm the Setup method");
        }

        [Test]
        public async Task TestDatabase_IsEmpty()
        {
            Console.WriteLine("I'm the 'TestDatabase_IsEmpty' method");

            // Setup is called
            // Arrange
            var dbContext = new ApplicationDbContext(_dbContextOptions);

            // Act
            var count = await dbContext.Set<Participant>().CountAsync();

            // Assert
            Assert.AreEqual(0, count);

            // TearDown is called
        }

        [Test]
        public async Task TestDatabase_IsEmpty_BasedOnCollection()
        {
            // Setup is called
            // Arrange
            var dbContext = new ApplicationDbContext(_dbContextOptions);

            // Act
            var count = await dbContext.Set<Participant>().ToListAsync();

            // Assert
            Assert.IsEmpty(count);

            // TearDown is called
        }

        [Test]
        public async Task TestCreate_Invalid()
        {
            // Setup is called
            // Arrange
            var dbContext = new ApplicationDbContext(_dbContextOptions);

            await dbContext.AddAsync(new Participant()
            {
                Id = 1,
                Height = 167.69m,
                Weight = 79.54m,
                StudyCode = "BE-000001",
                HasEverDrank = false,
                HasEverSmoked = false
            });

            await dbContext.AddAsync(new Participant()
            {
                Id = 2,
                Height = 167.69m,
                Weight = 79.54m,
                StudyCode = "BE-000002",
                HasEverDrank = false,
                HasEverSmoked = false
            });

            // Act
            var count = await dbContext.Set<Participant>().CountAsync();

            // Assert
            Assert.AreEqual(0, count, "My count is wrong");

            // TearDown is called
        }

        [Test]
        public async Task TestCreate_IsValid()
        {
            // Setup is called
            // Arrange
            var dbContext = new ApplicationDbContext(_dbContextOptions);

            await dbContext.AddAsync(new Participant()
            {
                Id = 1,
                Height = 167.69m,
                Weight = 79.54m,
                StudyCode = "BE-000001",
                HasEverDrank = false,
                HasEverSmoked = false
            });

            await dbContext.AddAsync(new Participant()
            {
                Id = 2,
                Height = 167.69m,
                Weight = 79.54m,
                StudyCode = "BE-000002",
                HasEverDrank = false,
                HasEverSmoked = false
            });

            await dbContext.SaveChangesAsync();

            // Act
            var count = await dbContext.Set<Participant>().CountAsync();

            // Assert
            Assert.AreEqual(2, count, "My count is wrong");

            // TearDown is called
        }

        [Test]
        public async Task TestDelete_IsValid()
        {
            // Setup is called
            // Arrange
            var dbContext = new ApplicationDbContext(_dbContextOptions);
            var participantId = 1;

            await dbContext.AddAsync(new Participant()
            {
                Id = participantId,
                Height = 124.6m,
                Weight = 59.6m,
                StudyCode = "BE-000001",
                HasEverDrank = true,
                HasEverSmoked = false
            });

            await dbContext.SaveChangesAsync();

            // Act
            var participantToDelete = await dbContext.Set<Participant>().FindAsync(participantId);
            dbContext.Remove(participantToDelete);
            await dbContext.SaveChangesAsync();

            var deletedParticipant = await dbContext.Set<Participant>().FindAsync(participantId);

            // Assert
            Assert.IsNull(deletedParticipant);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("I'm the TearDown method");
            // when test is finished
        }
    }
}