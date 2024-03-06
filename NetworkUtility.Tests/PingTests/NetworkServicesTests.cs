using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkUtility.Ping;
using FluentAssertions;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServicesTests
    {
        [Fact]
        public void NetworkServices_SendPing_ReturnString()
        {
            //Arrange
            var pingServices = new NetworkServices();

            //Act
            var result = pingServices.SengPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping sent");
        }
        [Theory]
        [InlineData(1,1,2)]
        public void NetworkServices_PingTimeOut_ReturnInt(int a,int b,int expected)
        {
            //Arrange
            var pingServices=new NetworkServices();

            //Act
            var result = pingServices.PingTimeout(a, b);

            //Assert

            result.Should().Be(expected);

        }


    }
}
