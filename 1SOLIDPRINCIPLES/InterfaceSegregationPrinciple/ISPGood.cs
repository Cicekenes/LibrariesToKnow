using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1SOLIDPRINCIPLES.InterfaceSegregationPrinciple.GoodAndBad
{
	//Class Library => Read Imp
	//Class Library => Create/Update/Delete Imp

	public class Product
	{
		public int Id { get; set; }
        public string Name { get; set; }

    }

    public class ReadRepository : IReadRepository
    {
        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList()
        {
            throw new NotImplementedException();
        }
    }

    public class WriteRepository : IWriteRepository
    {
        public void Create(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product p)
        {
            throw new NotImplementedException();
        }

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }
    }

    //public interface IProductRepository
    //{
    //	List<Product> GetList();
    //	Product GetById(int id);

    //}

    public interface IReadRepository
    {
        List<Product> GetList();
        Product GetById(int id);

    }
    public interface IWriteRepository
	{
        void Create(Product p);
        void Update(Product p);
        void Delete(Product p);
    }
}
