using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class AddressPostalMap : MapperBase, IAddressPostalMap
    { // AddressPostalMap class opener
        public AddressPostalData Map(DataRow record)
        {
            try
            {
                return new AddressPostalData() { 
                    Country = NullCheck<string>(record["country"]),
                    PostalCode = NullCheck<string>(record["postal_code"]),
                    StateCode = NullCheck<string>(record["state_code"]),
                    StateFullName = NullCheck<string>(record["state_full_name"]),
                    CityName = NullCheck<string>(record["city_name"]),
                    CountyName = NullCheck<string>(record["county_name"]),
                    TimeZone = NullCheck<int>(record["time_zone"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AddressPostalMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public AddressPostalData Map(IDataReader record)
        {
            try
            {
                return new AddressPostalData()
                {
                    Country = NullCheck<string>(record["country"]),
                    PostalCode = NullCheck<string>(record["postal_code"]),
                    StateCode = NullCheck<string>(record["state_code"]),
                    StateFullName = NullCheck<string>(record["state_full_name"]),
                    CityName = NullCheck<string>(record["city_name"]),
                    CountyName = NullCheck<string>(record["county_name"]),
                    TimeZone = NullCheck<int>(record["time_zone"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AddressPostalMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AddressPostalData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@country", entity.Country));
            sql_params.Add(new SqlParameter("@postal_code", entity.PostalCode));
            sql_params.Add(new SqlParameter("@state_code", entity.StateCode));
            sql_params.Add(new SqlParameter("@state_full_name", entity.StateFullName));
            sql_params.Add(new SqlParameter("@city_name", entity.CityName));
            sql_params.Add(new SqlParameter("@county_name", entity.CountyName));
            sql_params.Add(new SqlParameter("@time_zone", entity.TimeZone));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(AddressPostalData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@postal_code", entity.PostalCode));
            sql_params.Add(GetOutParam());

            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(int address_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@postal_code", address_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // AddressPostalMap class closer
}