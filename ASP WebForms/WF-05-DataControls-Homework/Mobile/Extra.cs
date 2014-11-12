using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobile
{
    public class Extra
    {
        public static IEnumerable<Extra> GetExtras()
        {
            return new List<Extra>()
            {
                new Extra() {Name = "Electring windows", Cost = 1.84m},
                new Extra() {Name = "4x4", Cost = 1.84m},
                new Extra() {Name = "Electring side windows", Cost = 1.84m},
                new Extra() {Name = "Cabrio", Cost = 1.84m},
                new Extra() {Name = "Alarm", Cost = 1.84m},
                new Extra() {Name = "Spare wheel", Cost = 1.84m},
                new Extra() {Name = "Chick", Cost = 1.84m},
                new Extra() {Name = "Air conditioner", Cost = 1.84m},
            };
        }

        public string Name { get; set; }

        public decimal Cost { get; set; }
    }
}