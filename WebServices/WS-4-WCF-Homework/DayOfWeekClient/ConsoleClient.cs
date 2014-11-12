namespace DayOfWeekClient
{
    using System;
    using System.Text;

    public class ConsoleClient
    {
        static void Main()
        {
            var client = new ServiceReferenceDayOfWeekInBulgarian.DayOfWeekGetterClient();

            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine(client.GetDayOfWeek(new DateTime(1988, 11, 14)));

            client.Close();
        }
    }
}
