using System;
using Xunit;
using NetworkUtility.Ping;
using NetworkUtility.DNS;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Net.NetworkInformation;
using FakeItEasy;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dNS;
        public NetworkServiceTests()
        {
            //Dependencies
            _dNS = A.Fake<IDNS>();//Creates a fake DNS for test (Mock DNS)

            //SUT - Software Under Test
            _pingService = new NetworkService(_dNS);
        }
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            A.CallTo(() => _dNS.SendDNS()).Returns(true);
            // Act

            var result = _pingService.SendPing();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping send!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange

            // Act
            var result = _pingService.PingTimeout(a, b);
            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        public void NetworkService_PingTimeout_ReturnDate()
        {
            // Arrange

            // Act

            var result = _pingService.LastPingDate();

            // Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
            // result.Should().Contain("Success", Exactly.Once());
        }
        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            // Act
            var result = _pingService.GetPingOptions();
            // Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }
        [Fact]
        public void NetworkService_MostRecentPings_ReturnIEnumarable()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            // Act
            var result = _pingService.MostRecentPings();
            // Assert
            result.Should().BeOfType<PingOptions[]>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
