using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class CommentTypeMap : MapperBase, ICommentTypeMap
    { // CommentTypeMap class opener
        public CommentTypeData Map(DataRow record)
        {
            try
            {
                return new CommentTypeData() { 
                    CommentTypeKey = NullCheck<int>(record["comment_type_key"]),
                    CommentTypeCategory = NullCheck<string>(record["comment_type_category"]),
                    CommentTypeCode = NullCheck<string>(record["comment_type_code"]),
                    CommentTypeName = NullCheck<string>(record["comment_type_name"]),
                    CommentTypeDesc = NullCheck<string>(record["comment_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"CommentTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public CommentTypeData Map(IDataReader record)
        {
            try
            {
                return new CommentTypeData()
                {
                    CommentTypeKey = NullCheck<int>(record["comment_type_key"]),
                    CommentTypeCategory = NullCheck<string>(record["comment_type_category"]),
                    CommentTypeCode = NullCheck<string>(record["comment_type_code"]),
                    CommentTypeName = NullCheck<string>(record["comment_type_name"]),
                    CommentTypeDesc = NullCheck<string>(record["comment_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"CommentTypeMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(CommentTypeData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@comment_type_key", entity.CommentTypeKey));
            sql_params.Add(new SqlParameter("@comment_type_category", entity.CommentTypeCategory));
            sql_params.Add(new SqlParameter("@comment_type_code", entity.CommentTypeCode));
            sql_params.Add(new SqlParameter("@comment_type_name", entity.CommentTypeName));
            sql_params.Add(new SqlParameter("@comment_type_desc", entity.CommentTypeDesc));
            sql_params.Add(GetOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(CommentTypeData entity)
        {
            return MapParamsForDelete(entity.CommentTypeKey);
        }

        public List<SqlParameter> MapParamsForDelete(int comment_type_key)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@comment_type_key", comment_type_key));
            sql_params.Add(GetOutParam());

            return sql_params;
        }
    } // CommentTypeMap class closer
}