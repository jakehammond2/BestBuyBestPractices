using System.Data;
using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(conn);

Console.WriteLine("Type a new Department name");

var newDepartment = Console.ReadLine();

repo.InsertDepartment(newDepartment);

var departments = repo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.Name);
}

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("*** List of all the products: ***");
var repoP = new DapperProductRepository(conn);

var products = repoP.GetAllProducts(); 

foreach (var product in products)
{
    Console.WriteLine(product.Name, product.Price, product.CategoryID);
}
Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("What is the name of your product?");
var namep = Console.ReadLine();
Console.WriteLine("What is the price of your product?");
double pricep = double.Parse(Console.ReadLine());
Console.WriteLine("What is the CategoryID of your product?");
int CategoryIDp = int.Parse(Console.ReadLine());

repoP.CreateProduct(namep, pricep, CategoryIDp);
var newListOfProducts = repoP.GetAllProducts();
foreach (var product in newListOfProducts)
{
    Console.WriteLine(product.Name, product.Price, product.CategoryID);
}

Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine($"What do you want to update your price of {namep} to?");
var updatep = double.Parse(Console.ReadLine());

repoP.UpdateProductPrice(namep, updatep);
var newListWithUpdatedPrice = repoP.GetAllProducts();
foreach (var product in newListWithUpdatedPrice)
{
    Console.WriteLine(product.Name, product.Price, product.CategoryID);
}

Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("What product do you want to delete? Give me a ProductID");
var deletep = int.Parse(Console.ReadLine());

repoP.DeleteProducts(deletep);
var newDeletedList = repoP.GetAllProducts(); 
foreach (var product in newDeletedList)
{
    Console.WriteLine(product.Name, product.Price, product.CategoryID);
}


