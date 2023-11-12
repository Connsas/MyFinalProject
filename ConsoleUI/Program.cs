using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IProductService productManager = new ProductManager(new EfProductDal());

            //productManager.Add(new Product { ProductId = 6, CategoryId = 2, ProductName = "Mouse Pad", UnitInStock = 35, UnitPrice = 70 });

            foreach (var product in productManager.GetByUnitPrice(20,50))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}