using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalizerHostAndClient
{
    public class StringAnalizerHost
    {
        Uri serviceAddress = new Uri("http://localhost:1234/calc");
            ServiceHost selfHost = new ServiceHost(typeof(ServiceCalculator), serviceAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                System.Console.WriteLine("The service is started at endpoint " + serviceAddress);

                System.Console.WriteLine("Press [Enter] to exit.");
                System.Console.ReadLine();
            }
    }
}
