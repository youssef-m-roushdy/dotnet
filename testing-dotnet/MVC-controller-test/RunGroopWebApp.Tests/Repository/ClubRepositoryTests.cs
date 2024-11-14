using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Data.Enum;
using RunGroopWebApp.Models;
using RunGroopWebApp.Repository;
using Xunit;

namespace RunGroopWebApp.Tests.Repository
{
    public class ClubRepositoryTests
    {
        // This method sets up an in-memory database context for testing.
        // The database is created using the Entity Framework Core's in-memory database provider.
        // If the database has fewer than 10 clubs, 10 clubs will be added to the in-memory database.
        private async Task<ApplicationDbContext> GetDbContext()
        {
            // Configuring the options for the in-memory database with a unique name for isolation between tests.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Creating the database context
            var databaseContext = new ApplicationDbContext(options);

            // Ensuring that the database is created (required for the in-memory database).
            databaseContext.Database.EnsureCreated();

            // Check if there are any clubs in the database; if not, add 10 dummy clubs.
            if (await databaseContext.Clubs.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    // Adding a sample club to the in-memory database.
                    databaseContext.Clubs.Add(
                        new Club()
                        {
                            Title = "Running Club 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        });
                    // Save the changes to the database after adding each club.
                    await databaseContext.SaveChangesAsync();
                }
            }
            // Return the prepared database context for use in tests.
            return databaseContext;
        }

        // Test to check if the Add method in the ClubRepository works and returns a boolean value.
        [Fact]
        public async void ClubRepository_Add_ReturnsBool()
        {
            // Arrange
            // Create a new club instance that will be added to the repository.
            var club = new Club()
            {
                Title = "Running Club 1",
                Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                Description = "This is the description of the first cinema",
                ClubCategory = ClubCategory.City,
                Address = new Address()
                {
                    Street = "123 Main St",
                    City = "Charlotte",
                    State = "NC"
                }
            };

            // Initialize a new in-memory database context for the test.
            var dbContext = await GetDbContext();

            // Create an instance of ClubRepository with the in-memory database context.
            var clubRepository = new ClubRepository(dbContext);

            // Act
            // Add the new club to the repository and store the result (which should be a boolean).
            var result = clubRepository.Add(club);

            // Assert
            // Ensure that the result of adding the club is true, indicating a successful add operation.
            result.Should().BeTrue();
        }

        // Test to verify that the GetByIdAsync method returns a valid club object when provided with a valid ID.
        [Fact]
        public async void ClubRepository_GetByIdAsync_ReturnsClub()
        {
            // Arrange
            // Define a club ID to be retrieved from the repository (using ID = 1 for this test).
            var id = 1;

            // Initialize a new in-memory database context for the test.
            var dbContext = await GetDbContext();

            // Create an instance of ClubRepository with the in-memory database context.
            var clubRepository = new ClubRepository(dbContext);

            // Act
            // Retrieve the club by its ID from the repository (the result should be a task that returns a Club).
            var result = clubRepository.GetByIdAsync(id);

            // Assert
            // Ensure that the result is not null, meaning a club was found with the provided ID.
            result.Should().NotBeNull();

            // Ensure that the result is of type Task<Club>, indicating the correct return type.
            result.Should().BeOfType<Task<Club>>();
        }
    }
}
