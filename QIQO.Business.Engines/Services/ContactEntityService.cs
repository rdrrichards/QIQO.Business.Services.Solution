using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class ContactEntityService : IContactEntityService
    {
        public Contact Map(ContactData contact_data)
        {
            return new Contact()
            {
                ContactKey = contact_data.ContactKey,
                ContactTypeKey = contact_data.ContactTypeKey,
                ContactType = (QIQOContactType)contact_data.ContactTypeKey,
                ContactActiveFlg = contact_data.ContactActiveFlg,
                ContactDefaultFlg = contact_data.ContactDefaultFlg,
                ContactValue = contact_data.ContactValue,
                EntityKey = contact_data.EntityKey,
                EntityTypeKey = contact_data.EntityTypeKey,
                AddedUserID = contact_data.AuditAddUserId,
                AddedDateTime = contact_data.AuditAddDatetime,
                UpdateUserID = contact_data.AuditUpdateUserId,
                UpdateDateTime = contact_data.AuditUpdateDatetime
            };
        }
        public ContactData Map(Contact contact)
        {
            return new ContactData()
            {
                ContactKey = contact.ContactKey,
                ContactTypeKey = (int)contact.ContactType,
                ContactActiveFlg = contact.ContactActiveFlg,
                ContactDefaultFlg = contact.ContactDefaultFlg,
                ContactValue = contact.ContactValue,
                EntityKey = contact.EntityKey,
                EntityTypeKey = contact.EntityTypeKey
            };
        }
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
