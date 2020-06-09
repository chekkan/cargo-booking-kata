using System;
using Xunit;

namespace CargoBooking.UnitTests
{
    public class VesselTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(200)]
        public void VesselCapacity(int origCapacity)
        {
            var sut = new Vessel(origCapacity);
            Assert.Equal(origCapacity, sut.Capacity);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        public void NegativeCapacityThrows(int capacity)
        {
            var errors = Assert.Throws<ArgumentOutOfRangeException>(() => new Vessel(capacity));
            Assert.Equal("capacity", errors.ParamName);
        }
    }
}
