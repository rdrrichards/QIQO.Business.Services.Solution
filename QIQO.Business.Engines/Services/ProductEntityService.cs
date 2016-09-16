using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class ProductEntityService : IProductEntityService
    {
        public Product Map(ProductData product_data)
        {
            return new Product()
            {
                ProductKey = product_data.ProductKey,
                ProductType = (QIQOProductType)product_data.ProductTypeKey,
                ProductName = product_data.ProductName,
                ProductDesc = product_data.ProductDesc,
                ProductCode = product_data.ProductCode,
                ProductNameShort = product_data.ProductNameShort,
                ProductNameLong = product_data.ProductNameLong,
                ProductImagePath = product_data.ProductImagePath,
                AddedUserID = product_data.AuditAddUserId,
                AddedDateTime = product_data.AuditAddDatetime,
                UpdateUserID = product_data.AuditUpdateUserId,
                UpdateDateTime = product_data.AuditUpdateDatetime,
                ProductDescCombo = product_data.ProductCode.PadRight(21 - product_data.ProductCode.Length) + product_data.ProductDesc
            };
        }

        public ProductData Map(Product product)
        {
            return new ProductData()
            {
                ProductKey = product.ProductKey,
                ProductTypeKey = (int)product.ProductType,
                ProductName = product.ProductName,
                ProductDesc = product.ProductDesc,
                ProductCode = product.ProductCode,
                ProductNameShort = product.ProductNameShort,
                ProductNameLong = product.ProductNameLong,
                ProductImagePath = product.ProductImagePath
            };
        }
        public ProductType Map(ProductTypeData product_type_data)
        {
            return new ProductType()
            {
                ProductTypeKey = product_type_data.ProductTypeKey,
                ProductTypeCategory = product_type_data.ProductTypeCategory,
                ProductTypeCode = product_type_data.ProductTypeCode,
                ProductTypeName = product_type_data.ProductTypeName,
                ProductTypeDesc = product_type_data.ProductTypeDesc,
                AddedUserID = product_type_data.AuditAddUserId,
                AddedDateTime = product_type_data.AuditAddDatetime,
                UpdateUserID = product_type_data.AuditUpdateUserId,
                UpdateDateTime = product_type_data.AuditUpdateDatetime
            };
        }

        public ProductTypeData Map(ProductType product_type)
        {
            return new ProductTypeData()
            {
                ProductTypeKey = product_type.ProductTypeKey,
                ProductTypeCategory = product_type.ProductTypeCategory,
                ProductTypeCode = product_type.ProductTypeCode,
                ProductTypeName = product_type.ProductTypeName,
                ProductTypeDesc = product_type.ProductTypeDesc
            };
        }
    }
}
