using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobile
{
    public class Producer
    {
        public static IEnumerable<Producer> GetProducers()
        {
            return new List<Producer>()
            {
                new Producer() 
                {
                    Name = "BMW",
                    Models = new List<string>() { "ix530", "320", "7" }
                },
                new Producer()
                {
                    Name = "Audi",
                    Models = new List<string>() { "R6", "A4", "R8" }

                },
                new Producer()
                {
                    Name = "Opel",
                    Models = new List<string>() { "Astra", "Calibra", "Insighnia" }
                }
            };
        }

        public IEnumerable<string> Models { get; set; }

        public string Name { get; set; }
    }
}