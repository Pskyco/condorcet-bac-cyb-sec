using System;
using System.Threading.Tasks;
using medical_data.Entities;
using medical_data.Persistence;
using medical_data.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace medical_data.tests
{
    public class TestParticipantService
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
        public async Task TestUpdate_IsValid()
        {
            // Setup is called
            // Arrange
            var dbContext = new ApplicationDbContext(_dbContextOptions);

            var participantId = 1;
            var oldHeight = 167.69m;
            var oldWeight = 79.54m;
            var oldHasEverDrank = false;
            var oldHasEverSmoked = false;

            await dbContext.AddAsync(new Participant()
            {
                Id = participantId,
                Height = oldHeight,
                Weight = oldWeight,
                StudyCode = "BE-000001",
                HasEverDrank = oldHasEverDrank,
                HasEverSmoked = oldHasEverSmoked
            });

            await dbContext.SaveChangesAsync();

            // Act

            var newHeight = 149.12m;
            var newWeight = 71.36m;
            var newHasEverDrank = true;
            var newHasEverSmoked = true;

            var participantService = new ParticipantService(dbContext);
            await participantService.UpdateParticipant(participantId, newWeight, newHeight, newHasEverDrank,
                newHasEverSmoked);

            // Assert
            var participant = await dbContext.Set<Participant>().FindAsync(participantId);
            Assert.IsNotNull(participant);
            Assert.AreEqual(newWeight, participant.Weight, "Weight has not been updated");
            Assert.AreEqual(newHeight, participant.Height, "Height has not been updated");
            Assert.AreEqual(newHasEverDrank, participant.HasEverDrank, "HasEverDrank has not been updated");
            Assert.AreEqual(newHasEverSmoked, participant.HasEverSmoked, "HasEverSmoked has not been updated");

            Assert.AreNotEqual(newWeight, oldWeight);
            Assert.AreNotEqual(newHeight, oldHeight);
            Assert.AreNotEqual(newHasEverDrank, oldHasEverDrank);
            Assert.AreNotEqual(newHasEverSmoked, oldHasEverSmoked);
        }
        
        [Test]
        public async Task TestUpdate_IsInvalid()
        {
            // Setup is called
            // Arrange
            var dbContext = new ApplicationDbContext(_dbContextOptions);
            var participantService = new ParticipantService(dbContext);

            // Act
            

            // Assert
            Assert.ThrowsAsync<Exception>(() => participantService.UpdateParticipant(9145335, 121m, 12m, true, true));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("I'm the TearDown method");
            // when test is finished
        }
    }
}