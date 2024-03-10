using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1SOLIDPRINCIPLES.SingleResponsibilityPrincible
{
    public class ProductGood
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductRepository
    {
        private static List<ProductGood> ProductList = new List<ProductGood>();

        public List<ProductGood> GetProducts => ProductList;
        public ProductRepository()
        {
            ProductList = new()
            {
                new ProductGood(){Id=1,Name="Kalem1"},
                new ProductGood(){Id=2,Name="Kalem2"},
                new ProductGood(){Id=3,Name="Kalem3"},
                new ProductGood(){Id=4,Name="Kalem4"},
                new ProductGood(){Id=5,Name="Kalem5"}
            };
        }
        public void SaveOrUpdate(ProductGood product)
        {
            var hasProduct = ProductList.Any(p => p.Id == product.Id);

            if (!hasProduct)
            {
                ProductList.Add(product);
            }
            else
            {
                var index = ProductList.FindIndex(x => x.Id == product.Id);
                ProductList[index] = product;
            }
        }

        public void Delete(int id)
        {
            var hasProduct = ProductList.Find(x => x.Id == id);
            if (hasProduct == null)
                throw new Exception("Ürün bulunamadı");
            ProductList.Remove(hasProduct);
        }
    }
    public class ProductPresenter
    {
        public void WriteToConsole(List<ProductGood> ProductList)
        {
            ProductList.ForEach(x => Console.WriteLine($"{x.Id} - {x.Name}"));
        }
    }
}

