using System.Collections.Generic;

namespace CargoBooking
{
    public interface IBookingPolicy
    {
        bool IsSatisfiedBy(int reservedCapacity, Vessel vessel, Cargo cargo);
    }
}