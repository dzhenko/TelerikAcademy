namespace Log4Net
{
    using log4net;
    using log4net.Config;
    public class Log4NetTest
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Log4NetTest));
        public static void Main()
        {
            BasicConfigurator.Configure();

            logger.Info("Info log");
            logger.Error("Error log");
            logger.Warn("Warn log");
            logger.Fatal("Fatal log");
        }
    }
}
