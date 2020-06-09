using System;
using Moq;
using Xunit;

namespace CargoBooking.UnitTests
{
    public class BookingManagerTests
    {
        private Mock<IBookingConfirmationGenerator> confNumGenMock;
        private BookingManager sut;

        public BookingManagerTests()
        {
            confNumGenMock = new Mock<IBookingConfirmationGenerator>();
            confNumGenMock.Setup(gen => gen.Generate()).Returns(Guid.NewGuid().ToString());
            var bookingPolicy = new NormalBookingPolicy();
            sut = new BookingManager(confNumGenMock.Object, bookingPolicy);
        }

        [Fact]
        public void ReturnsBookingConfirmationNumber()
        {
            string confirmationNumber = Guid.NewGuid().ToString();
            confNumGenMock.Setup(gen => gen.Generate()).Returns(confirmationNumber);
            var result = sut.Book(new Vessel(10), new Cargo(5));
            Assert.Equal(confirmationNumber, result.Value);
        }

        [Fact]
        public void ReturnsVesselAtCapacity()
        {
            Vessel vessel = new Vessel(10);
            sut.Book(vessel, new Cargo(6));
            var actual = sut.Book(vessel, new Cargo(5));
            Assert.True(actual.HasError);
            Assert.IsType<VesselAtCapacity>(actual.Error);
        }

        [Fact]
        public void CanBookVesselThatFitsAfterOneThatDoesnt()
        {
            string confirmationNumber = Guid.NewGuid().ToString();
            confNumGenMock.Setup(gen => gen.Generate()).Returns(confirmationNumber);
            var vessel = new Vessel(5);
            sut.Book(vessel, new Cargo(6));
            var actual = sut.Book(vessel, new Cargo(5));
            Assert.Equal(confirmationNumber, actual.Value);
        }

        [Fact]
        public void OverbookingPolicyAccepts()
        {
            string confirmationNumber = Guid.NewGuid().ToString();
            confNumGenMock.Setup(gen => gen.Generate()).Returns(confirmationNumber);
            var bookingPolicy = new OverbookingPolicy();
            sut = new BookingManager(confNumGenMock.Object, bookingPolicy);
            var vessel = new Vessel(10);
            var actual = sut.Book(vessel, new Cargo(11));
            Assert.Equal(confirmationNumber, actual.Value);
        }

        [Fact]
        public void OverbookingPolicyRejects()
        {
            string confirmationNumber = Guid.NewGuid().ToString();
            confNumGenMock.Setup(gen => gen.Generate()).Returns(confirmationNumber);
            var bookingPolicy = new OverbookingPolicy();
            sut = new BookingManager(confNumGenMock.Object, bookingPolicy);
            var vessel = new Vessel(10);
            var actual = sut.Book(vessel, new Cargo(12));
            Assert.IsType<VesselAtCapacity>(actual.Error);
        }
    }
}
