namespace School.Services
{
    public interface IMessagingService
    {
        public void SendMessage(string student);
        public bool ReceiveMessage();
    }
}