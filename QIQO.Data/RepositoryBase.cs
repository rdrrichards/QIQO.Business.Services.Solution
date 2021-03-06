﻿using QIQO.Common.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace QIQO.Data
{
    public abstract class RepositoryBase<T> : IRepository<T> //, IMapper<T> 
        where T : class, IEntity, new()
        //where M : class, IMapper, new()
    {
        //readonly IMainDBContext entity_context;
        //readonly IMapperFactory mapper_factory;
        protected readonly IMapper<T> Mapper;

        public RepositoryBase(IMapper<T> map_factory)
        {
            //entity_context = dbc;
            //mapper_factory = map_factory;
            Mapper = map_factory; //.GetObjectMapper<IMapper<T>>();
        }

        // What steps would we need to take in order to make this happen?
        //  Mapper<T> - which could be tricky since we want to avoid using reflection
        //  We could use a mapper factory and get the mapper class from the container
        //          This would entail creating a mapper interface, which shouldn't be difficult
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
                rows.Add(Mapper.Map(dr));
            dr.Close();
            return rows;
        }

        protected T MapRow(DbDataReader dr)
        {
            if (dr.Read())
                return Mapper.Map(dr);
            else
                return new T();
            //var row = new T();
            //while (dr.Read())
            //    row = Mapper.Map(dr);
            //dr.Close();
            //return row;
        }

        public abstract void Delete(T entity);
        public abstract void DeleteByCode(string entity_code);
        public abstract void DeleteByID(int entity_key);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetByCode(string account_code, string entity_code);
        public abstract T GetByID(int entity_key);
        public abstract int Insert(T entity);
        public abstract int Save(T entity);
    }
}
