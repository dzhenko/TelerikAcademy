namespace Cars.Client.Logger
{
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.Write(message);
        }
    }
}
