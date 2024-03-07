using NetworkUtility.Ping;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Net.NetworkInformation;
using NetworkUtility.DNS;
using FakeItEasy;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServicesTests
    {
        public readonly NetworkServices pingServices;
        private readonly IDNS _dNS;
        public NetworkServicesTests()
        {
            //dependencies
            _dNS = A.Fake<IDNS>();

            pingServices = new NetworkServices(_dNS);
        }
        [Fact]
        public void NetworkServices_SendPing_ReturnString()
        {
            //Arrange
            A.CallTo(() => _dNS.SendDNS()).Returns(true);
           // var pingServices = new NetworkServices();

            //Act
            var result = pingServices.SengPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping sent");
            result.Should().Contain("Success", Exactly.Once());
        }
        [Theory]
        [InlineData(1,1,2)]
        public void NetworkServices_PingTimeOut_ReturnInt(int a,int b,int expected)
        {
            //Arrange
         //   var pingServices=new NetworkServices();

            //Act
            var result = pingServices.PingTimeout(a, b);

            //Assert

            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);

        }

        [Fact]
        public void NetworkServices_LastPingDate_ReturnDate()
        {
            //Arrange
            // var pingServices = new NetworkServices();

            //Act
            var result = pingServices.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2025));
        }
        [Fact]
        public void NetworkServices_GetPingOptions_ReturnObject()   //Testing Objects
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1

            };
            //Act
            var result = pingServices.GetPingOptions();

            //Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1); 
        }
        [Fact]
        public void NetworkServices_MostRecentPings_ReturnObject()   //Testing IEnumerable
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1

            };
            //Act
            var result = pingServices.MostRecentPings();

            //Assert
           // result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
