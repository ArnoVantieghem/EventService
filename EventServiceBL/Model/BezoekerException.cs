namespace EventServiceBL.Model
{
    public class BezoekerException : Exception
    {
        public BezoekerException(string? message) : base(message)
        {
        }

        public BezoekerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
