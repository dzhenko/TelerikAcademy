namespace Company.SampleDataGenerator.Loggers
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
