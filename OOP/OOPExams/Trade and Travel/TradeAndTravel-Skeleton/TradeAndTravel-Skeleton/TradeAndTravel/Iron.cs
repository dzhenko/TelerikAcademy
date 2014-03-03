using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Iron : Item
    {
        const int GeneralIronValue = 2;

        public Iron(string name, Location location = null)
            : base(name, Iron.GeneralIronValue, ItemType.Iron, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>();
        }
    }
}
