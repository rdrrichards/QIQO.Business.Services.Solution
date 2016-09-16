using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IProductBusinessEngine : IBusinessEngine
    {
        bool ProductDelete(Product product);
        int ProductSave(Product product);
        Product GetProductByCode(string product_code, Company company);
        Product GetProductByCode(string product_code, string company_code);
        Product GetProductByID(int product_key);
        List<Product> GetProductsByCompany(Company company);
    }
}