using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Common.Core
{
    public static class EntityServiceExtensions
    {
        public static List<TEntity> Map<TModel, TEntity>(this IEntityService<TModel, TEntity> svc, IEnumerable<TModel> entities)
            where TModel : IModel
            where TEntity : IEntity
        {
            var maps = new List<TEntity>();
            foreach (var ent in entities)
            {
                maps.Add(svc.Map(ent));
            }
            return maps;
        }

        public static List<TModel> Map<TModel, TEntity>(this IEntityService<TModel, TEntity> svc, IEnumerable<TEntity> entities)
            where TModel : IModel
            where TEntity : IEntity
        {
            var maps = new List<TModel>();
            foreach (var ent in entities)
            {
                maps.Add(svc.Map(ent));
            }
            return maps;
        }
    }

    public static class ModelExtensions
    {
        public static void AddAll<T, L>(this List<T> m_col, List<L> models)
            where T : IModel
            where L : IModel
        {
            foreach (var mod in models)
            {
                //m_col.Add(mod);
            }
        }
    }

}
