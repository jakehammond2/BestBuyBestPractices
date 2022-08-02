using System;
namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAllProducts();
        public void CreateProduct(string name, double price, int categoryID); 

    }



}

