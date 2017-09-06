using System;
using Xunit;
using ParadeCore.Domain.Models;

namespace ParadeCore.Tests.Domain
{
    public class Member_Should
    {
        [Theory]
        [InlineData("S12345678")]
        [InlineData("b87654321")]
        public void SetServiceNumberWhenValid(string serviceNumber)
        {
            var member = new Member(serviceNumber);

            Assert.True(member.ServiceNumber.Equals(serviceNumber.ToUpper()));
        }

        [Theory]
        [InlineData("111209")]
        [InlineData("kljawetalkjsf")]
        [InlineData("1A2345678")]
        [InlineData("A12 345 678")]
        public void ThrowsWhenServiceNumberIsInvalid(string serviceNumber)
        {
            Assert.Throws<ArgumentException>(() => new Member(serviceNumber));
        }
        
        [Fact]
        public void ThrowsWhenServiceNumberIsNullOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() => new Member(""));
            Assert.Throws<ArgumentNullException>(() => new Member(null));
        }
    }
}