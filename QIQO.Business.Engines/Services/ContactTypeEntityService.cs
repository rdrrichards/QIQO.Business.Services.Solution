using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{


    public class ContactTypeEntityService : IContactTypeEntityService
    {
        public ContactType Map(ContactTypeData contact_type_data)
        {
            return new ContactType()
            {
                ContactTypeKey = contact_type_data.ContactTypeKey,
                ContactTypeCategory = contact_type_data.ContactTypeCategory,
                ContactTypeCode = contact_type_data.ContactTypeCode,
                ContactTypeName = contact_type_data.ContactTypeName,
                ContactTypeDesc = contact_type_data.ContactTypeDesc,
                AddedUserID = contact_type_data.AuditAddUserId,
                AddedDateTime = contact_type_data.AuditAddDatetime,
                UpdateUserID = contact_type_data.AuditUpdateUserId,
                UpdateDateTime = contact_type_data.AuditUpdateDatetime
            };
        }

        public ContactTypeData Map(ContactType contact_type)
        {
            return new ContactTypeData()
            {
                ContactTypeKey = contact_type.ContactTypeKey,
                ContactTypeCategory = contact_type.ContactTypeCategory,
                ContactTypeCode = contact_type.ContactTypeCode,
                ContactTypeName = contact_type.ContactTypeName,
                ContactTypeDesc = contact_type.ContactTypeDesc
            };
        }
    }
}