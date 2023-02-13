namespace School.Services
{
    public interface IMessagingService
    {
        public Task<string> SendMessage(string student, CancellationToken cancellationToken = default);
        // public bool ReceiveMessage();
    }
}