namespace BattleNetShop.ReportsModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductsTaxes")]
    public class ProductTax
    {
        [Key]
        public long Id { get; set; }

        public string ProductName { get; set; }

        public double Amount { get; set; }
    }
}
