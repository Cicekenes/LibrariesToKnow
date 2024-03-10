using _1SOLIDPRINCIPLES.DependencyInversionPrinciple.DIPGoodAndBad;

var ProductService = new ProductService(new ProductRepositoryFromOracleServer());

ProductService.GetAll().ForEach(product =>Console.WriteLine(product));

Console.Read();