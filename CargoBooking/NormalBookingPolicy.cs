using System.Collections.Generic;
using System.Linq;

namespace CargoBooking
{
    public class NormalBookingPolicy : IBookingPolicy
    {
        public bool IsSatisfiedBy(int reservedCapacity, Vessel vessel, Cargo cargo)
        {
            return reservedCapacity + cargo.Size <= vessel.Capacity;
        }
    }
}