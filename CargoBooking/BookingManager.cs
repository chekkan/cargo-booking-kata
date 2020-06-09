using System;

namespace CargoBooking
{
    public class BookingManager
    {
        private readonly IBookingConfirmationGenerator generator;

        public BookingManager(IBookingConfirmationGenerator generator)
        {
            this.generator = generator;
        }

        public Result<string, VesselAtCapacity> Book(Vessel vessel, Cargo cargo)
        {
            var result = vessel.Assign(cargo);
            return result == null
                ? new Result<string, VesselAtCapacity>(this.generator.Generate())
                : new Result<string, VesselAtCapacity>(result);
        }
    }
}