using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using RunGroopWebApp.Controllers;
using RunGroopWebApp.Interfaces;
using FakeItEasy;
using RunGroopWebApp.Models;
using Microsoft.AspNetCore.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace RunGroopWebApp.Tests.Controller
{
    public class ClubControllerTests
    {
        private readonly ClubController _clubController;
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;
        private readonly HttpContextAccessor _httpContextAccessor;
        public ClubControllerTests()
        {
            // Dependencies
            // Mock by fake values to avoid deal with the real repository we want to fake it
            // Want to return fake values
            _clubRepository = A.Fake<IClubRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();// extension method is static it can not be tested
            // Stay away from static functions because you can't unit test them

            //SUT - System Under Test
            // The controller we want to test him 
            _clubController = new ClubController(_clubRepository, _photoService, _httpContextAccessor);
        }
        [Fact]
        public void ClubController_Index_ReturnsSuccess()
        {
            // Arrange - what do i need to bring in
            var clubs = A.Fake<IEnumerable<Club>>();
            A.CallTo(() => _clubRepository.GetAll()).Returns(clubs);
            // Act
            var result = _clubController.Index();
            // Assert - Object check actions
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void ClubController_Detail_ReturnsSuccess()
        {
            // Arrange - what do i need to bring in
            var id = 1; // Id to refere to the fake club
            var club = A.Fake<Club>(); // fake club to return from the id
            A.CallTo(() => _clubRepository.GetByIdAsync(id)).Returns(club);// by using this id he will return the fake club
            // Act
            var result = _clubController.Detail(id);
            // Assert - Object check actions
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}