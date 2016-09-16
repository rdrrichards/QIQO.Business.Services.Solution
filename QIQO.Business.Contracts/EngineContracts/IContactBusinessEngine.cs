using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IContactBusinessEngine : IBusinessEngine
    {
        bool ContactDelete(Contact contact);
        int ContactSave(Contact contact);
        List<Contact> GetContactsByEntity(int entity_key, QIQOEntityType entity_type);
    }
}