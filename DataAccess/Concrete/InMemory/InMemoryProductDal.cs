using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1,ProductName="Name1",UnitsInStock=10, UnitPrice=1000},
                new Product{ProductId=2, CategoryId=1,ProductName="Name2",UnitsInStock=15, UnitPrice=1200},
                new Product{ProductId=3, CategoryId=2,ProductName="Name3",UnitsInStock=20, UnitPrice=1400},
                new Product{ProductId=4, CategoryId=2,ProductName="Name4",UnitsInStock=25, UnitPrice=1500},
                new Product{ProductId=5, CategoryId=2,ProductName="Name5",UnitsInStock=30, UnitPrice=1600},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(productToDelete);
            /* 
            Product productToDelete;
            foreach (var p in _products)
            {
                if (p.Id==product.Id)
                {
                    productToDelete = p;
                }
            }
            _products.Remove(product);
            */
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
                return _products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate= _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
