namespace CargoBooking
{
    public class Result<T1, T2>
    {
        public Result(T1 value)
        {
            Value = value;
        }

        public Result(T2 error)
        {
            HasError = true;
            Error = error;
        }

        public T1 Value { get; }
        public bool HasError { get; }
        public T2 Error { get; }
    }
}