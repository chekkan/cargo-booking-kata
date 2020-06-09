using System.Collections.Generic;

namespace CargoBooking
{
    public class OverbookingPolicy : IBookingPolicy
    {
        public bool IsSatisfiedBy(int reservedCapacity, Vessel vessel, Cargo cargo) 
            => reservedCapacity + cargo.Size <= vessel.Capacity * 1.1;
    }
}