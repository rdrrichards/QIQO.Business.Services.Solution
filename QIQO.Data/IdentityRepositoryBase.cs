using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Data;

namespace QIQO.Data
{
    public abstract class IdentityRepositoryBase<T> : IIdentityRepository<T>
        where T : class, IIdentityEntity, new()
    {
        protected readonly IIdentityMapper<T> Mapper;

        public IdentityRepositoryBase(IIdentityMapper<T> map_factory)
        {
            Mapper = map_factory;
        }

        protected IEnumerable<T> MapRows(DataSet ds)
        {
            List<T> rows = new List<T>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                T com = new T();
                com = Mapper.Map(row);
                rows.Add(com);
            }

            return rows;
        }

        protected T MapRow(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                T com = new T();
                com = Mapper.Map(row);
                return com;
            }
            else
                return new T();
        }

        public abstract void Delete(T entity);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetByID(Guid id);
        public abstract T GetByName(string name);
        public abstract int Save(T entity);
    }
}
