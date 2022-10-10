namespace TableBooking.Models.Services
{
    internal class PhoneSender : IMessageSender
    {
        private Message _message { get; set; }

        public PhoneSender(Message message)
        {
            _message = message;
        }
        public void Send()
        {
            Console.WriteLine(_message.TextMessage);
        }

        public Task SendAsync()
        {
            throw new NotImplementedException();
        }
    }
}