using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

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
            var rows = new List<T>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rows.Add(Mapper.Map(row));
            }

            return rows;
        }

        protected T MapRow(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
                return Mapper.Map(ds.Tables[0].Rows[0]);
            else
                return new T();
        }

        protected IEnumerable<T> MapRows(DbDataReader dr)
        {
            var rows = new List<T>();
            while (dr.Read())
                rows.Add(MapRow(dr));
            dr.Close();
            return rows;
        }

        protected T MapRow(IDataReader ds)
        {
            return Mapper.Map(ds);
        }

        public abstract void Delete(T entity);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetByID(Guid id);
        public abstract T GetByName(string name);
        public abstract int Save(T entity);
    }
}
