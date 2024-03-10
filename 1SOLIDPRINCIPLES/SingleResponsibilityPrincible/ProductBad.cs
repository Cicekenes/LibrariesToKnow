namespace _1SOLIDPRINCIPLES.SingleResponsibilityPrincible
{
    public class ProductBad
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static List<ProductBad> ProductList = new List<ProductBad>();

        public List<ProductBad> GetProducts => ProductList;
        public ProductBad()
        {
            ProductList = new()
            {
                new ProductBad(){Id=1,Name="Kalem1"},
                new ProductBad(){Id=2,Name="Kalem2"},
                new ProductBad(){Id=3,Name="Kalem3"},
                new ProductBad(){Id=4,Name="Kalem4"},
                new ProductBad(){Id=5,Name="Kalem5"}
            };
        }

        public void SaveOrUpdate(ProductBad product)
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

        public void WriteToConsole()
        {
            ProductList.ForEach(x => Console.WriteLine($"{x.Id} - {x.Name}"));
        }
    }

}
