using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class VendorMap : MapperBase, IVendorMap
    { // VendorMap class opener
        public VendorData Map(DataRow record)
        {
            try
            {
                return new VendorData()
                {
                    VendorKey = NullCheck<int>(record["vendor_key"]),
                    VendorCode = NullCheck<string>(record["vendor_code"]),
                    VendorName = NullCheck<string>(record["vendor_name"]),
                    VendorDesc = NullCheck<string>(record["vendor_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"VendorMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(VendorData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@vendor_key", entity.VendorKey));
            sql_params.Add(new SqlParameter("@vendor_code", entity.VendorCode));
            sql_params.Add(new SqlParameter("@vendor_name", entity.VendorName));
            sql_params.Add(new SqlParameter("@vendor_desc", entity.VendorDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(VendorData entity)
        {
            return MapParamsForDelete(entity.VendorKey);
        }

        public List<SqlParameter> MapParamsForDelete(int vendor_key)
        {
            List<SqlParameter> sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@vendor_key", vendor_key));
            sql_params.Add(GetOutParam());
            return sql_params;
        }
    } // VendorMap class closer
}