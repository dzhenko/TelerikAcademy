using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StringAnalizerServiceLibrary
{
    public class StringAnalizer : IStringAnalizer
    {
        public int CountSecondStringOccurancesInFirstString(string first, string second)
        {
            return first.Split(new string[] { second }, StringSplitOptions.RemoveEmptyEntries).Count() - 1;
        }
    }
}
