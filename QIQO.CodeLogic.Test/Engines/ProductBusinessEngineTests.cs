using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System.Collections.Generic;

namespace QIQO.Business.Engines.Tests
{
    [TestClass()]
    public class ProductBusinessEngineTests
    {
        [TestMethod()]
        public void GetProductByCodeTestAndCompanyObject()
        {
            // Arrange
            ProductData test_product_data = new ProductData() { ProductCode = "TEST", ProductKey = 1};
            Product test_product = new Product() { ProductCode = "TEST", ProductKey = 1 };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            Mock<IProductRepository> product_repo = new Mock<IProductRepository>();
            Mock<IProductBusinessEngine> product_be = new Mock<IProductBusinessEngine>();
            Mock<IEntityAttributeBusinessEngine> entity_att_be = new Mock<IEntityAttributeBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IProductTypeBusinessEngine> pt_be = new Mock<IProductTypeBusinessEngine>();
            Mock<IProductEntityService> prod_es = new Mock<IProductEntityService>();

            product_repo.Setup(mock => mock.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(test_product_data);
            product_be.Setup(mock => mock.GetProductByCode(It.IsAny<string>(),It.IsAny<Company>())).Returns(test_product);
            prod_es.Setup(mock => mock.Map(It.IsAny<ProductData>())).Returns(test_product);
            repo_factory.Setup(mock => mock.GetDataRepository<IProductRepository>()).Returns(product_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_att_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductBusinessEngine>()).Returns(product_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductTypeBusinessEngine>()).Returns(pt_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IProductEntityService>()).Returns(prod_es.Object);

            ProductBusinessEngine prod_business_engine = new ProductBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            Product ret_val = prod_business_engine.GetProductByCode("TEST", test_comp);

            //Assert
            Assert.IsTrue(ret_val.ProductCode == test_product.ProductCode);
        }

        [TestMethod()]
        public void GetProductByCodeTestAndCompanyCode()
        {
            // Arrange
            ProductData test_product_data = new ProductData() { ProductCode = "TEST", ProductKey = 1 };
            Product test_product = new Product() { ProductCode = "TEST", ProductKey = 1 };
            Mock<IProductRepository> product_repo = new Mock<IProductRepository>();
            Mock<IProductBusinessEngine> product_be = new Mock<IProductBusinessEngine>();
            Mock<IEntityAttributeBusinessEngine> entity_att_be = new Mock<IEntityAttributeBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IProductTypeBusinessEngine> pt_be = new Mock<IProductTypeBusinessEngine>();
            Mock<IProductEntityService> prod_es = new Mock<IProductEntityService>();

            product_repo.Setup(mock => mock.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(test_product_data);
            product_be.Setup(mock => mock.GetProductByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(test_product);
            prod_es.Setup(mock => mock.Map(It.IsAny<ProductData>())).Returns(test_product);
            repo_factory.Setup(mock => mock.GetDataRepository<IProductRepository>()).Returns(product_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_att_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductBusinessEngine>()).Returns(product_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductTypeBusinessEngine>()).Returns(pt_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IProductEntityService>()).Returns(prod_es.Object);

            ProductBusinessEngine prod_business_engine = new ProductBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            Product ret_val = prod_business_engine.GetProductByCode("TEST", "TEST");

            //Assert
            Assert.IsTrue(ret_val.ProductCode == test_product.ProductCode);
        }

        [TestMethod()]
        public void GetProductByIDTest()
        {
            // Arrange
            ProductData test_product_data = new ProductData() { ProductCode = "TEST", ProductKey = 1 };
            Product test_product = new Product() { ProductCode = "TEST", ProductKey = 1 };
            Mock<IProductRepository> product_repo = new Mock<IProductRepository>();
            Mock<IProductBusinessEngine> product_be = new Mock<IProductBusinessEngine>();
            Mock<IEntityAttributeBusinessEngine> entity_att_be = new Mock<IEntityAttributeBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IProductTypeBusinessEngine> pt_be = new Mock<IProductTypeBusinessEngine>();
            Mock<IProductEntityService> prod_es = new Mock<IProductEntityService>();

            product_repo.Setup(mock => mock.GetByID(It.IsAny<int>())).Returns(test_product_data);
            product_be.Setup(mock => mock.GetProductByID(It.IsAny<int>())).Returns(test_product);
            prod_es.Setup(mock => mock.Map(It.IsAny<ProductData>())).Returns(test_product);
            repo_factory.Setup(mock => mock.GetDataRepository<IProductRepository>()).Returns(product_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_att_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductBusinessEngine>()).Returns(product_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductTypeBusinessEngine>()).Returns(pt_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IProductEntityService>()).Returns(prod_es.Object);

            ProductBusinessEngine prod_business_engine = new ProductBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            Product ret_val = prod_business_engine.GetProductByID(1);

            //Assert
            Assert.IsTrue(ret_val.ProductCode == test_product.ProductCode);
        }

        [TestMethod()]
        public void GetProductsByCompanyTest()
        {
            // Arrange
            List<ProductData> test_product_data = new List<ProductData>() {
                new ProductData() { ProductCode = "TEST1", ProductKey = 1 },
                new ProductData() { ProductCode = "TEST2", ProductKey = 2 }
            };
            List<Product> test_product = new List<Product>() {
                new Product() { ProductCode = "TEST1", ProductKey = 1 },
                new Product() { ProductCode = "TEST2", ProductKey = 2 }
            };
            CompanyData test_comp_data = new CompanyData() { CompanyKey = 1, CompanyCode = "TEST" };
            Company test_comp = new Company() { CompanyKey = 1, CompanyCode = "TEST" };
            Product test_prod = new Product() { ProductCode = "TEST", ProductKey = 1 };
            Mock<IProductRepository> product_repo = new Mock<IProductRepository>();
            Mock<IProductBusinessEngine> product_be = new Mock<IProductBusinessEngine>();
            Mock<IEntityAttributeBusinessEngine> entity_att_be = new Mock<IEntityAttributeBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IProductTypeBusinessEngine> pt_be = new Mock<IProductTypeBusinessEngine>();
            Mock<IProductEntityService> prod_es = new Mock<IProductEntityService>();

            product_repo.Setup(mock => mock.GetAll(It.IsAny<CompanyData>())).Returns(test_product_data);
            product_be.Setup(mock => mock.GetProductsByCompany(It.IsAny<Company>())).Returns(test_product);
            prod_es.Setup(mock => mock.Map(It.IsAny<ProductData>())).Returns(test_prod);
            repo_factory.Setup(mock => mock.GetDataRepository<IProductRepository>()).Returns(product_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_att_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductBusinessEngine>()).Returns(product_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductTypeBusinessEngine>()).Returns(pt_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IProductEntityService>()).Returns(prod_es.Object);

            ProductBusinessEngine prod_business_engine = new ProductBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            List<Product> ret_val = prod_business_engine.GetProductsByCompany(test_comp);

            //Assert
            Assert.IsTrue(ret_val.Count == 2);
        }

        [TestMethod()]
        public void ProductDeleteTest()
        {
            // Arrange
            ProductData test_product_data = new ProductData() { ProductCode = "TEST", ProductKey = 1 };
            Product test_product = new Product() { ProductCode = "TEST", ProductKey = 1 };
            Mock<IProductRepository> product_repo = new Mock<IProductRepository>();
            Mock<IProductBusinessEngine> product_be = new Mock<IProductBusinessEngine>();
            Mock<IEntityAttributeBusinessEngine> entity_att_be = new Mock<IEntityAttributeBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IProductTypeBusinessEngine> pt_be = new Mock<IProductTypeBusinessEngine>();
            Mock<IProductEntityService> prod_es = new Mock<IProductEntityService>();

            product_repo.Setup(mock => mock.Delete(It.IsAny<ProductData>()));
            product_be.Setup(mock => mock.ProductDelete(It.IsAny<Product>())).Returns(true);
            prod_es.Setup(mock => mock.Map(It.IsAny<Product>())).Returns(test_product_data);
            repo_factory.Setup(mock => mock.GetDataRepository<IProductRepository>()).Returns(product_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_att_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductBusinessEngine>()).Returns(product_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductTypeBusinessEngine>()).Returns(pt_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IProductEntityService>()).Returns(prod_es.Object);

            ProductBusinessEngine prod_business_engine = new ProductBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            bool ret_val = prod_business_engine.ProductDelete(test_product);

            //Assert
            Assert.IsTrue(ret_val);
        }

        [TestMethod()]
        public void ProductSaveTest()
        {
            // Arrange
            ProductData test_product_data = new ProductData() { ProductCode = "TEST", ProductKey = 1 };
            Product test_product = new Product() { ProductCode = "TEST", ProductKey = 1 };
            Mock<IProductRepository> product_repo = new Mock<IProductRepository>();
            Mock<IProductBusinessEngine> product_be = new Mock<IProductBusinessEngine>();
            Mock<IEntityAttributeBusinessEngine> entity_att_be = new Mock<IEntityAttributeBusinessEngine>();
            Mock<IDataRepositoryFactory> repo_factory = new Mock<IDataRepositoryFactory>();
            Mock<IBusinessEngineFactory> be_factory = new Mock<IBusinessEngineFactory>();
            Mock<IEntityServiceFactory> es_factory = new Mock<IEntityServiceFactory>();
            Mock<IProductTypeBusinessEngine> pt_be = new Mock<IProductTypeBusinessEngine>();
            Mock<IProductEntityService> prod_es = new Mock<IProductEntityService>();

            product_repo.Setup(mock => mock.Save(It.IsAny<ProductData>())).Returns(1);
            product_be.Setup(mock => mock.ProductSave(It.IsAny<Product>())).Returns(1);
            prod_es.Setup(mock => mock.Map(It.IsAny<Product>())).Returns(test_product_data);
            repo_factory.Setup(mock => mock.GetDataRepository<IProductRepository>()).Returns(product_repo.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IEntityAttributeBusinessEngine>()).Returns(entity_att_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductBusinessEngine>()).Returns(product_be.Object);
            be_factory.Setup(mock => mock.GetBusinessEngine<IProductTypeBusinessEngine>()).Returns(pt_be.Object);
            es_factory.Setup(mock => mock.GetEntityService<IProductEntityService>()).Returns(prod_es.Object);

            ProductBusinessEngine prod_business_engine = new ProductBusinessEngine(repo_factory.Object, be_factory.Object, es_factory.Object);

            //Act
            int ret_val = prod_business_engine.ProductSave(test_product);

            //Assert
            Assert.IsTrue(ret_val == test_product.ProductKey);
        }
    }
}