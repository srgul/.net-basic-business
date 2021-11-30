using DataAccess.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product {ProductId=1, CategoryId=1, ProductName="Bardak", UnitInStock=10, UnitPrice=10},
                new Product {ProductId=2, CategoryId=1, ProductName="Kamera", UnitInStock=3, UnitPrice=500 },
                new Product {ProductId=3, CategoryId=2, ProductName="Telefon", UnitInStock=1000, UnitPrice=1200 },
                new Product {ProductId=4, CategoryId=2, ProductName="Klavye", UnitInStock=10, UnitPrice=100 },
                new Product {ProductId=5, CategoryId=2, ProductName="Fare", UnitInStock=10, UnitPrice=50 },
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {            
            Product productToDelete = _products.SingleOrDefault( p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName     = product.ProductName;
            productToUpdate.CategoryId      = product.CategoryId;
            productToUpdate.UnitInStock     = product.UnitInStock;
            productToUpdate.UnitPrice       = product.UnitPrice;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();      
        }
    }
}
