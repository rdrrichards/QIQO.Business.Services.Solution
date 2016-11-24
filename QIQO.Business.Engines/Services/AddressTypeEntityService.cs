using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class AddressTypeEntityService : IAddressTypeEntityService
    {
        public AddressType Map(AddressTypeData address_type_data)
        {
            return new AddressType()
            {
                AddressTypeKey = address_type_data.AddressTypeKey,
                AddressTypeCode = address_type_data.AddressTypeCode,
                AddressTypeName = address_type_data.AddressTypeName,
                AddressTypeDesc = address_type_data.AddressTypeDesc,
                AddedUserID = address_type_data.AuditAddUserId,
                AddedDateTime = address_type_data.AuditAddDatetime,
                UpdateUserID = address_type_data.AuditUpdateUserId,
                UpdateDateTime = address_type_data.AuditUpdateDatetime,
            };
        }

        public AddressTypeData Map(AddressType address_type)
        {
            return new AddressTypeData()
            {
                AddressTypeKey = address_type.AddressTypeKey,
                AddressTypeCode = address_type.AddressTypeCode,
                AddressTypeName = address_type.AddressTypeName,
                AddressTypeDesc = address_type.AddressTypeDesc
            };
        }
    }
}