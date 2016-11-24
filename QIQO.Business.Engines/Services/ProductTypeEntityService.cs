using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class ProductTypeEntityService : IProductTypeEntityService
    {
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