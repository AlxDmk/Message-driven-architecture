using System.Timers;
using Messaging;

namespace Restaurant.Booking.Models
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new();

        private readonly Producer _producer =
            new("BookingNotification", "localhost");


        public Restaurant()
        {
            for (ushort i = 1; i <= 10; i++)
                _tables.Add(new Table(i));

        }        

        public void BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду, я подберу столик и подтвержу вашу бронь. Вам придет уведомление!");

            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.SeatCount > countOfPersons && t.State == State.Free);
                await Task.Delay(5000);
                table?.SetState(State.Booked);
              
                _producer.Send(table is null
                    ? "УВЕДОМЛЕНИЕ! К сожалению, сейчас все столики заняты"
                    : $"УВЕДОМЛЕНИЕ! Готово! Ваш столик номер {table.Id}");                
            });

        }        

        #region TIMER UNSET BOOKING    

        public async void UnsetBooking(object? sender, ElapsedEventArgs e)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(_tables, t => t.SetState(State.Free));
                _producer.Send("Вся бронь со столиков снята");
                

            });
        }

        #endregion
    }
}
