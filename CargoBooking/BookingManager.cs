using System.Collections.Generic;
using System.Linq;

namespace CargoBooking
{
    public class BookingManager
    {
        private readonly IBookingConfirmationGenerator generator;
        private readonly IBookingPolicy bookingPolicy;
        private readonly Dictionary<Vessel, List<Cargo>> reservations;

        public BookingManager(IBookingConfirmationGenerator generator, IBookingPolicy bookingPolicy)
        {
            this.generator = generator;
            this.bookingPolicy = bookingPolicy;
            reservations = new Dictionary<Vessel, List<Cargo>>();
        }

        public Result<string, VesselAtCapacity> Book(Vessel vessel, Cargo cargo)
        {
            if (!bookingPolicy.IsSatisfiedBy(ReservedCapacity(vessel), vessel, cargo))
            {
                return new Result<string, VesselAtCapacity>(new VesselAtCapacity());
            }
            if (!reservations.ContainsKey(vessel))
            {
                reservations.Add(vessel, new List<Cargo>());
            }
            reservations[vessel].Add(cargo);
            return new Result<string, VesselAtCapacity>(this.generator.Generate());
        }

        private int ReservedCapacity(Vessel vessel)
            => reservations.ContainsKey(vessel)
                ? reservations[vessel].Sum(c => c.Size)
                : 0;
    }
}