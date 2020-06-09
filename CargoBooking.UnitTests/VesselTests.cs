using Xunit;

namespace CargoBooking.UnitTests
{
    public class VesselTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(200)]
        public void VesselCapacityDecreasesWhenCargoIsAssigned(int origCapacity)
        {
            var sut = new Vessel(origCapacity);
            Cargo cargo = new Cargo(2);
            var result = sut.Assign(cargo);
            Assert.Equal(origCapacity - cargo.Size, sut.Capacity);
            Assert.Null(result);
        }

        [Fact]
        public void VesselAtCapacity()
        {
            var sut = new Vessel(10);
            var result = sut.Assign(new Cargo(6));
            Assert.Null(result);
            result = sut.Assign(new Cargo(5));
            Assert.IsType<VesselAtCapacity>(result);
            Assert.Equal(4, sut.Capacity);
        }
    }
}
