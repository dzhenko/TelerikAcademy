using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking
{
    public class Ingred
    {
        public  decimal quantity;
        public  string measurment;

    }

    class Program
    {
        static decimal ConvertMeasurment(string from, string target)
        {
            decimal counter = 1;

            switch (from)
            {                                     
                case "tablespoons"  : counter = counter * 15    ; break;
                case "tbsps"        : counter = counter * 15    ; break;
                                                         
                case "teaspoons"    : counter = counter * 5    ; break;
                case "tsps"         : counter = counter * 5    ; break;
                                                         
                case "liters"       : counter = counter * 1000    ; break;
                case "ls"           : counter = counter * 1000    ; break;
                                                         
                case "milliliters"  : counter = counter *  1   ; break;
                case "mls"          : counter = counter *  1   ; break;
                                                         
                case "fluid ounces" : counter = counter *  30   ; break;
                case "fl ozs"       : counter = counter *  30   ; break;
                                                        
                case "gallons"      : counter = counter *  3840   ; break;
                case "gals"         : counter = counter *  3840   ; break;
                                                         
                case "pints"        : counter = counter *  480   ; break;
                case "pts"          : counter = counter *  480   ; break;
                                                         
                case "quarts"       : counter = counter *  960   ; break;
                case "qts"          : counter = counter *  960   ; break;
                                                          
                case "cups"         : counter = counter * 240      ; break;
            }
            switch (target)
            {
                case "tablespoons": counter = counter / 15; break;
                case "tbsps": counter = counter / 15; break;

                case "teaspoons": counter = counter / 5; break;
                case "tsps": counter = counter / 5; break;

                case "liters": counter = counter / 1000; break;
                case "ls": counter = counter / 1000; break;

                case "milliliters": counter = counter / 1; break;
                case "mls": counter = counter / 1; break;

                case "fluid ounces": counter = counter / 30; break;
                case "fl ozs": counter = counter / 30; break;

                case "gallons": counter = counter / 3840; break;
                case "gals": counter = counter / 3840; break;

                case "pints": counter = counter / 480; break;
                case "pts": counter = counter / 480; break;

                case "quarts": counter = counter / 960; break;
                case "qts": counter = counter / 960; break;

                case "cups": counter = counter / 240; break;
            }
            return counter;
        }

        static void Main()
        {
            //input
            int ingrCount = int.Parse(Console.ReadLine());

            Dictionary<string, Ingred> allOfIngridients = new Dictionary<string, Ingred>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < ingrCount; i++)
            {
                string[] item = Console.ReadLine().Split(new char[]{':'},StringSplitOptions.RemoveEmptyEntries);
                if (allOfIngridients.ContainsKey(item[2]))
                {
                    allOfIngridients[item[2]].quantity = allOfIngridients[item[2]].quantity +
                       (decimal.Parse(item[0]) * (ConvertMeasurment(item[1], allOfIngridients[item[2]].measurment)));
                }
                else
                {
                    Ingred temp = new Ingred();
                    temp.measurment = item[1];
                    temp.quantity = decimal.Parse(item[0]);
                    allOfIngridients.Add(item[2], temp);
                }
            }
            
            int putIn = int.Parse(Console.ReadLine());
            for (int i = 0; i < putIn; i++)
            {
                string[] item = Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (allOfIngridients.ContainsKey(item[2]))
                {
                    allOfIngridients[item[2]].quantity = allOfIngridients[item[2]].quantity -
                       (decimal.Parse(item[0]) * (ConvertMeasurment(item[1], allOfIngridients[item[2]].measurment)));
                }
            }
            foreach (var item in allOfIngridients)
            {
                if (item.Value.quantity > 0)
                {
                    Console.WriteLine("{0:0.00}:{1}:{2}",item.Value.quantity,item.Value.measurment,item.Key);
                }
            }
        }
    }
}
