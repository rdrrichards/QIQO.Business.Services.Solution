using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class AddressPostalData : IEntity
    { // AddressPostal class opener
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string StateCode { get; set; }
        public string StateFullName { get; set; }
        public string CityName { get; set; }
        public string CountyName { get; set; }
        public int TimeZone { get; set; }

        public int EntityRowKey
        {
            get { return Int32.Parse(PostalCode); }
            set { PostalCode = value.ToString(); }
        }
    } // AddressPostal class closer
}