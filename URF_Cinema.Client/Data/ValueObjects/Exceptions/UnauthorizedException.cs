using URF_Cinema.Client.Data.ValueObjects.Common;

namespace URF_Cinema.Client.Data.ValueObjects.Exceptions
{
    public class UnauthorizedException : ExceptionBase
    {
        public UnauthorizedException(string context, string key, string message, Tracker? tracker = null)
            : base(context, key, message, tracker)
        {
        }

        public UnauthorizedException(string context, string key, string message, Exception exception, Tracker? tracker = null)
            : base(context, key, message, exception, tracker)
        {
        }
    }
}
