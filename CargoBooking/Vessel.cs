#nullable enable

using System;
using System.Collections.Generic;

namespace CargoBooking
{
    public class Vessel
    {
        public int Capacity { get; }

        public Vessel(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            Capacity = capacity;
        }
    }
}
