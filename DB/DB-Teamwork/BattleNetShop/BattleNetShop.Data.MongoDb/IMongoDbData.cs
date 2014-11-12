namespace BattleNetShop.Data.MongoDb
{
    using System.Collections.Generic;

    using BattleNetShop.Model;

    /// <summary>
    /// Interface holding all mongoDb data manipulation
    /// </summary>
    public interface IMongoDbData
    {
        ICollection<Product> GetAllProducts();

        /// <summary>
        /// Returns all the product details from the database without their class type properties.
        /// </summary>
        /// <returns>A collection with all the product details in the database.</returns>
        ICollection<ProductDetails> GetAllProductDetails();

        /// <summary>
        /// Returns all the product categories from the database without their class type properties.
        /// </summary>
        /// <returns>A collection with all the product categories in the database.</returns>
        ICollection<ProductCategory> GetAllProductCategories();

        /// <summary>
        /// Returns all the vendors from the database without their class type properties.
        /// </summary>
        /// <returns>A collection with all the vendors in the database.</returns>
        ICollection<Vendor> GetAllVendors();

        /// <summary>
        /// Saves the givven sales expenses in the database.
        /// </summary>
        /// <param name="allExpenses">Collection of expenses to save in the database.</param>
        void SaveExpenses(IEnumerable<VendorExpense> allExpenses);
    }
}
