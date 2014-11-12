namespace BattleNetShop.Model
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PurchaseLocations")]
    public class PurchaseLocation
    {
        private ICollection<Purchase> purchases;

        public PurchaseLocation()
        {
            this.purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Purchase> Purchases
        {
            get
            {
                return this.purchases;
            }

            set
            {
                this.purchases = value;
            }
        }
    }
}
