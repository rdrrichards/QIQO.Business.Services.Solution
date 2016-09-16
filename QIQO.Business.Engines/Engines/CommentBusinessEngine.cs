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
    public class CommentBusinessEngine : EngineBase, ICommentBusinessEngine
    {
        private readonly ICommentRepository _comment_repo;
        private readonly ICommentEntityService _comment_es;
        public CommentBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact) //
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _comment_repo = _data_repository_factory.GetDataRepository<ICommentRepository>();
            _comment_es = _entity_service_factory.GetEntityService<ICommentEntityService>();
        }

        public bool CommentDelete(Comment comment)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var comment_data = _comment_es.Map(comment);
                _comment_repo.Delete(comment_data);
                return true;
            });
        }

        public int CommentSave(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            return ExecuteFaultHandledOperation(() =>
            {
                var prod_data = _comment_es.Map(comment);
                return _comment_repo.Insert(prod_data);
            });
        }
       
        public List<Comment> GetCommentsByEntity(int entity_key, QIQOEntityType entity_type)
        {
            Log.Info("Accessing CommentBusinessEngine GetCommentsByEntity function");
            return ExecuteFaultHandledOperation(() =>
            {
                var comments_data = _comment_repo.GetAll(entity_key, (int)entity_type);
                var comments = new List<Comment>();
                foreach (CommentData comment in comments_data)
                {
                    comments.Add(_comment_es.Map(comment));
                }
                return comments;
            });
        }
    }
}