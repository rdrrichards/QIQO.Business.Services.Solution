using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
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
    }
}
