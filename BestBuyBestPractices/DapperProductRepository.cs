using System;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository: IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@productName, @productPrice, @productCategoryID);",
                new {productName = name, productPrice = price, productCategoryID = categoryID } );
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("Select * From Products;");
        }

        public void UpdateProductPrice(string name, double price)
        {
            _connection.Execute("UPDATE Products Set Price = @newprice Where Name = @namep;",
                new { namep = name, newprice = price });

        }

        public void DeleteProducts(int ProductID)
        {
            _connection.Execute("DELETE FROM Products WHERE ProductID = @productID",
                new { productID = ProductID });

            Console.WriteLine("Product has been successfully deleted");
        }




    }
}


//CreateProduct(string name, double price, int categoryID)