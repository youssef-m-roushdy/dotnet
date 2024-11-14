using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;
using Xunit;

namespace PokemonReviewApp.Tests.Repository
{
    public class PokemonRepositoryTests
    {
        // This method sets up an in-memory database for testing
        private async Task<DataContext> GetDatabaseContext()
        {
            // Creates new DbContextOptions for DataContext using an in-memory database
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique database name for each test
                .Options;

            // Initialize the DataContext with the options
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated(); // Ensures the database is created

            // If there are no Pokémon in the database, add 10 Pokémon records
            if (await databaseContext.Pokemon.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    // Add Pokémon entities with related categories and reviews to the database
                    databaseContext.Pokemon.Add(
                        new Pokemon()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903, 1, 1), // Example birthdate for the Pokémon
                            PokemonCategories = new List<PokemonCategory>() // Pokémon's category
                            {
                                new PokemonCategory { Category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>() // Pokémon's reviews
                            {
                                new Review { Title="Pikachu", Text = "Pikachu is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Pikachu", Text = "Pikachu is great at battling rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Pikachu", Text = "Pikachu, Pikachu, Pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        });
                    await databaseContext.SaveChangesAsync(); // Save changes after each addition
                }
            }
            return databaseContext; // Return the configured DataContext
        }

        [Fact]
        public async void PokemonRepository_GetPokemon_ReturnsPokemon()
        {
            // Arrange
            var name = "Pikachu"; // Define the name of the Pokémon to search for
            var dbContext = await GetDatabaseContext(); // Initialize the in-memory database with seeded data
            var pokemonRepository = new PokemonRepository(dbContext); // Instantiate the repository with the in-memory database

            // Act
            var result = pokemonRepository.GetPokemon(name); // Call the GetPokemon method to retrieve the Pokémon

            // Assert
            result.Should().NotBeNull(); // Ensure that the result is not null, meaning the Pokémon was found
            result.Should().BeOfType<Pokemon>(); // Ensure the result is of type Pokémon
        }

        [Fact]
        public async void PokemonRepository_GetPokemonRating_ReturnsDecimalBetweenOneAndTen()
        {
            // Arrange
            var pokeId = 1; // Define the Pokémon's ID to search for
            var dbContext = await GetDatabaseContext(); // Initialize the in-memory database with seeded data
            var pokemonRepository = new PokemonRepository(dbContext); // Instantiate the repository with the in-memory database

            // Act
            var result = pokemonRepository.GetPokemonRating(pokeId); // Call the GetPokemonRating method to retrieve the rating

            // Assert
            result.Should().NotBe(0); // Ensure that the rating is not 0, meaning there is a valid rating
            result.Should().BeInRange(1, 10); // Ensure the rating is within the valid range of 1 to 10
        }
    }
}
