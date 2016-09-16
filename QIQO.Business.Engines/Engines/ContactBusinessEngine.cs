using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace QIQO.Business.Engines
{
    public class ContactBusinessEngine : EngineBase, IContactBusinessEngine
    {
        private readonly IContactRepository _contact_repo;
        private readonly IContactEntityService _contact_es;

        public ContactBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact) //
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _contact_repo = _data_repository_factory.GetDataRepository<IContactRepository>();
            _contact_es = _entity_service_factory.GetEntityService<IContactEntityService>();
        }

        public bool ContactDelete(Contact contact)
        {
            return ExecuteFaultHandledOperation(() =>
            {                
                var contact_data = _contact_es.Map(contact);
                _contact_repo.Delete(contact_data);
                return true;
            });
        }

        public int ContactSave(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact", "The contact parameter is invalid");

            return ExecuteFaultHandledOperation(() =>
            {
                IContactRepository contact_repo = _data_repository_factory.GetDataRepository<IContactRepository>();
                var prod_data = _contact_es.Map(contact);
                return contact_repo.Insert(prod_data);
            });
        }

        public List<Contact> GetContactsByEntity(int entity_key, QIQOEntityType entity_type)
        {
            Log.Info("Accessing CommentBusinessEngine GetCommentsByEntity function");
            return ExecuteFaultHandledOperation(() =>
            {
                IContactRepository comment_repo = _data_repository_factory.GetDataRepository<IContactRepository>();
                IEnumerable<ContactData> comments_data = comment_repo.GetAll(entity_key, (int)entity_type);
                List<Contact> comments = new List<Contact>();

                foreach (ContactData comment in comments_data)
                {
                    comments.Add(_contact_es.Map(comment));
                }
                return comments;
            });
        }
    }
}