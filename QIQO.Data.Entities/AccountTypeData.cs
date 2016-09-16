using System;
using QIQO.Common.Contracts;

namespace QIQO.Data.Entities
{
    public class AccountTypeData : CommonData, IEntity
    { // AccountType class opener
        public int AccountTypeKey { get; set; }
        public string AccountTypeCode { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeDesc { get; set; }

        public int EntityRowKey
        {
            get { return AccountTypeKey; }
            set { AccountTypeKey = value; }
        }
    } // AccountType class closer
}