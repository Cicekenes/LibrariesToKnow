using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1SOLIDPRINCIPLES.DependencyInversionPrinciple.DIPGoodAndBad
{
    public class ProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetAll()
        {
            return _repository.GetAll();
        }
    }

    public class ProductRepositoryFromSqlServer: IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "SqlServer Kalem1","SQLServer Kalem2"};
        }
    }
    public class ProductRepositoryFromOracleServer: IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "Oracle Kalem1","Oracle Kalem2"};
        }
    }

    public interface IRepository
    {
        List<string> GetAll();
    }
}
