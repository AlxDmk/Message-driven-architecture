namespace TableBooking.Models.Services
{
    internal class SMSSender : IMessageSender
    {
        private Message _message;

        public SMSSender(Message message)
        {
            _message = message;
        }
        public void Send()
        {
            Console.WriteLine(_message.TextMessage);
        }

        public Task SendAsync()
        {
            Task.Run(() =>
            {
                Console.WriteLine(_message.TextMessage);
            });
            return Task.CompletedTask;
        }
    }
}