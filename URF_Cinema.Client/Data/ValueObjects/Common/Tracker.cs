namespace URF_Cinema.Client.Data.ValueObjects.Common
{
    public class Tracker
    {
        public string RequestId { get; set; } = null!;

        public Tracker()
        {
        }

        public Tracker(string requestId)
        {
            RequestId = requestId;
        }
    }
}
