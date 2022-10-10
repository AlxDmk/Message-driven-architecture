namespace TableBooking.Models.Services
{
    internal interface IMessageSender
    {
        void Send();
        Task SendAsync();
    }
}