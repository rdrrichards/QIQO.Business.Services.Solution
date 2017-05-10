using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class AddressPostal: IModel
    {
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string StateCode { get; set; }
        [DataMember]
        public string StateFullName { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string CountyName { get; set; }
        [DataMember]
        public int TimeZone { get; set; }
    }
}
