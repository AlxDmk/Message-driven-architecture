using TableBooking.Models.Services;

namespace TableBooking.Models
{
    internal class Notification
    {
        private readonly IMessageSender _messageSender;

        public Notification(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public Task BookingAsync()
        {
            Task.Run(async () =>
            {
                await _messageSender.SendAsync();
            });
            return Task.CompletedTask;
        }

        public void Booking()
        {
            _messageSender.Send();

        }
    }
}