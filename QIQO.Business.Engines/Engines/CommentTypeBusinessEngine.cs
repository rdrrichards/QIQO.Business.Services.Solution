using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Caching;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QIQO.Business.Engines
{
    public class CommentTypeBusinessEngine : EngineBase, ICommentTypeBusinessEngine
    {
        private readonly ICache _cache;
        private readonly ICommentTypeRepository _repo_comment_type;
        private readonly ICommentTypeEntityService _comment_es;

        public CommentTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _repo_comment_type = _data_repository_factory.GetDataRepository<ICommentTypeRepository>();
            _comment_es = _entity_service_factory.GetEntityService<ICommentTypeEntityService>();
        }

        public CommentType GetTypeByKey(int type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var comment_types = _cache.Get(CacheKeys.CommentTypes) as List<CommentType>;
                if (comment_types != null)
                    return comment_types.Where(item => item.CommentTypeKey == type).FirstOrDefault();  //account_type_entry;

                return GetTypes().Where(item => item.CommentTypeKey == type).FirstOrDefault();
            });
        }

        public List<CommentType> GetTypes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<CommentType> comment_types = _cache.Get(CacheKeys.CommentTypes) as List<CommentType>;
                if (comment_types == null)
                {
                    Log.Debug("CommentTypeRepository GetAll called");
                    comment_types = new List<CommentType>();

                    var comment_type_data = _repo_comment_type.GetAll();

                    foreach (CommentTypeData account_type in comment_type_data)
                    {
                        comment_types.Add(_comment_es.Map(account_type));
                    }
                    
                    _cache.Set(CacheKeys.CommentTypes, comment_types);
                    Log.Debug("CommentTypeRepository GetAll complete");
                }
                return comment_types;
            });
        }

        public List<CommentType> GetTypesByCategory(string category)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var comment_types = _cache.Get(CacheKeys.CommentTypes) as List<CommentType>;
                if (comment_types != null)
                    return comment_types.Where(item => item.CommentTypeCategory == category).ToList();

                return GetTypes().Where(item => item.CommentTypeCategory == category).ToList();
            });
        }
        public int AddOrUpdateType(CommentType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                return _repo_comment_type.Insert(_comment_es.Map(type));
            });
        }

        public bool DeleteType(CommentType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                _repo_comment_type.Delete(_comment_es.Map(type));
                return true;
            });
        }

    }
}