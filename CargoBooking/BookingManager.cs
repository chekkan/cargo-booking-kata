using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoBooking
{
    public class BookingManager
    {
        private readonly IBookingConfirmationGenerator generator;
        private readonly Dictionary<Vessel, List<Cargo>> reservations;

        public BookingManager(IBookingConfirmationGenerator generator)
        {
            this.generator = generator;
            reservations = new Dictionary<Vessel, List<Cargo>>();
        }

        public Result<string, VesselAtCapacity> Book(Vessel vessel, Cargo cargo)
        {
            int reservedCapacity = ReservedCapacity(vessel);
            if (reservedCapacity + cargo.Size > vessel.Capacity)
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
        {
            return reservations.ContainsKey(vessel)
                ? reservations[vessel].Sum(c => c.Size)
                : 0;
        }
    }
}