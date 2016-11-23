using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Common.Core
{
    public static class RepositoryExtentions
    {
        //public static void SaveAll<T>(this IRepository<T> repo, IEnumerable<T> entities) where T : class, IEntity, new()
        //{
        //    foreach (var ent in entities)
        //    {
        //        repo.Save(ent);
        //    }
        //}
        public static List<int> SaveAll<T>(this IRepository<T> repo, IEnumerable<T> entities) where T : class, IEntity, new()
        {
            var ints = new List<int>();
            foreach (var ent in entities)
            {
                ints.Add(repo.Save(ent));
            }
            return ints;
        }
        public static bool DeleteAll<T>(this IRepository<T> repo, IEnumerable<T> entities) where T : class, IEntity, new()
        {
            foreach (var ent in entities)
            {
                repo.Delete(ent);
            }
            return true;
        }
    }

}
