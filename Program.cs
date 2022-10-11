using System.Diagnostics;
using Restaurant.Booking.Models;

using Timer = System.Timers.Timer;


internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var rest = new Restaurant.Booking.Models.Restaurant();

        #region TIMER UNSET BOOKING

        var timer = new Timer(20000);
        timer.Elapsed += rest.UnsetBooking;
        timer.AutoReset = true;
        timer.Enabled = true;

        #endregion

        //while (true)
        //{
        //    Console.WriteLine("Привет! желаете забронировать столик?\n1 - мы уведомим Вас по смс (асинхронно)\n2 - подождите на линии, мы вас оповестим (синхронно)\nЧтобы снять бронь со столика \n3 - мы уведомим вас по смс (асинхронно)\n4 - подождите на линии, мы вас оповестим (синхронно)");

        //    if (!int.TryParse(Console.ReadLine(), out int choice) || (choice - 1) * (4 - choice) < 0)
        //    {
        //        Console.WriteLine("Введите, пожалуйста от 1 до 4");
        //        continue;
        //    }

        //    var stopWatch = new Stopwatch();
        //    stopWatch.Start();

        //    switch (choice)
        //    {
        //        case 1:
        //            rest.BookFreeTableAsync(1);
        //            break;
        //        case 2:
        //            rest.BookFreeTable(1);
        //            break;
        //        case 3:
        //            Console.WriteLine("Введите номер столика");
        //            rest.UnsetBookingAsync(Convert.ToInt16(Console.ReadLine()));
        //            break;

        //        case 4:
        //            Console.WriteLine("Введите номер столика");
        //            rest.UnsetBooking(Convert.ToInt16(Console.ReadLine()));
        //            break;

        //        default:
        //            break;
        //    }

        //    Console.WriteLine("Спасибо за Ваш заказ!");
        //    stopWatch.Stop();
        //    var ts = stopWatch.Elapsed;
        //    Console.WriteLine($"{ts.Seconds:00} : {ts.Milliseconds:00}");

        //}

        while (true)
        {
            await Task.Delay(10000);
            Console.WriteLine("Привет! Желаете забронировать столик?");

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            rest.BookFreeTableAsync(1);

            Console.WriteLine("Спасибо за ваше обращение!");
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            Console.WriteLine($"{ts.Seconds:00}  {ts.Milliseconds:00}");


        }
    }
}

#region TIMER UNSET BOOKING

#endregion
