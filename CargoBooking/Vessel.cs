#nullable enable

namespace CargoBooking
{
    public class Vessel
    {
        public Vessel(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public VesselAtCapacity? Assign(Cargo cargo)
        {
            if (Capacity - cargo.Size < 0)
            {
                return new VesselAtCapacity();
            }
            Capacity -= cargo.Size;
            return null;
        }
    }
}
