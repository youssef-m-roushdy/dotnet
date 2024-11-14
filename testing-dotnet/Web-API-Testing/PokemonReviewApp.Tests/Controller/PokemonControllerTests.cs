using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PokemonReviewApp.Controllers;
using PokemonReviewApp.Interfaces;
using AutoMapper;
using FakeItEasy;
using PokemonReviewApp.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Tests.Controller
{
    public class PokemonControllerTests
    {
        // Fields to store fake instances of the dependencies used in the controller
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        // Constructor sets up the test class by creating fake dependencies using FakeItEasy
        public PokemonControllerTests()
        {
            _pokemonRepository = A.Fake<IPokemonRepository>(); // Mock IPokemonRepository
            _reviewRepository = A.Fake<IReviewRepository>();   // Mock IReviewRepository
            _mapper = A.Fake<IMapper>();                       // Mock IMapper
        }

        [Fact]
        public void PokemonController_GetPokemons_ReturnsOk()
        {
            // Arrange
            // Create a fake collection of PokemonDto to simulate data returned from repository
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonList = A.Fake<List<PokemonDto>>(); // Create a fake List<PokemonDto> to use in the mapping
            A.CallTo(() => _mapper.Map<List<PokemonDto>>(pokemons)).Returns(pokemonList); // Setup a call to the mapper to return the fake list
            var pokemonController = new PokemonController(_pokemonRepository, _reviewRepository, _mapper); // Create an instance of PokemonController with fake dependencies

            // Act
            var result = pokemonController.GetPokemons(); // Call the GetPokemons method from the controller

            // Assert
            // Check if the result is not null, meaning the response was successful
            result.Should().NotBeNull();
            // Check if the result is of type OkObjectResult, meaning the controller returned a 200 OK response
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void PokemonController_CreatePokemon_ReturnsOk()
        {
            // Arrange
            // Set up fake data for the method parameters
            int ownerId = 1;
            int catId = 2;
            var pokemonMap = A.Fake<Pokemon>();    // Fake Pokemon object to simulate database entity
            var pokemon = A.Fake<Pokemon>();       // Fake Pokemon object that represents the result of creating a Pokemon
            var pokemonCreate = A.Fake<PokemonDto>();  // Fake PokemonDto that represents the input DTO

            // Set up expected behavior for repository and mapper
            A.CallTo(() => _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate)).Returns(pokemon); // Call to check if a Pokemon already exists
            A.CallTo(() => _mapper.Map<Pokemon>(pokemonCreate)).Returns(pokemon); // Call to map PokemonDto to Pokemon entity
            A.CallTo(() => _pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap)).Returns(true); // Call to create the Pokemon in the repository

            var pokemonController = new PokemonController(_pokemonRepository, _reviewRepository, _mapper); // Create an instance of PokemonController with fake dependencies

            // Act
            var result = pokemonController.CreatePokemon(ownerId, catId, pokemonCreate); // Call the CreatePokemon method from the controller

            // Assert
            // Check if the result is not null, meaning the Pokemon creation was successful
            result.Should().NotBeNull();
        }
    }
}
