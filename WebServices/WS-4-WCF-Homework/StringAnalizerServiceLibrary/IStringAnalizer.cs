using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StringAnalizerServiceLibrary
{
    [ServiceContract]
    public interface IStringAnalizer
    {
        [OperationContract]
        int CountSecondStringOccurancesInFirstString(string first, string second);
    }
}
