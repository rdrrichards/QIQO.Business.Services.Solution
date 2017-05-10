using System;
using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class EntityProductEntityService : IEntityProductEntityService
    {
        public EntityProduct Map(EntityProductData ent)
        {
            throw new NotImplementedException();
        }

        public EntityProductData Map(EntityProduct entity_product)
        {
            return new EntityProductData()
            {
                ProductKey = entity_product.ProductKey,
                ProductTypeKey = (int)entity_product.ProductType,
                EntityProductSeq = entity_product.EntityProductSeq,
                EntityKey = entity_product.EntityProductEntityKey,
                EntityTypeKey = (int)entity_product.EntityProductEntityTypeKey,
                Comment = entity_product.Comment
            };
        }
        public EntityProduct Map(EntityProductData entity_product_data, ProductData product_data)
        {
            return new EntityProduct()
            {
                ProductKey = product_data.ProductKey,
                ProductType = (QIQOProductType)product_data.ProductTypeKey,
                ProductName = product_data.ProductName,
                ProductDesc = product_data.ProductDesc,
                ProductCode = product_data.ProductCode,
                ProductNameShort = product_data.ProductNameShort,
                ProductNameLong = product_data.ProductNameLong,
                ProductImagePath = product_data.ProductImagePath,

                EntityProductKey = entity_product_data.ProductKey,
                EntityProductType = (QIQOProductType)entity_product_data.ProductTypeKey,
                EntityProductSeq = entity_product_data.EntityProductSeq,
                EntityProductEntityKey = entity_product_data.EntityKey,
                EntityProductEntityTypeKey = (QIQOEntityType)entity_product_data.EntityTypeKey,
                Comment = entity_product_data.Comment,
                AddedUserID = entity_product_data.AuditAddUserId,
                AddedDateTime = entity_product_data.AuditAddDatetime,
                UpdateUserID = entity_product_data.AuditUpdateUserId,
                UpdateDateTime = entity_product_data.AuditUpdateDatetime
            };            
        }
    }
}
