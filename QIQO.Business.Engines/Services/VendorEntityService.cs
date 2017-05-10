using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class VendorEntityService : IVendorEntityService
    {
        public Vendor Map(VendorData vendor_data)
        {
            return new Vendor()
            {
                VendorKey = vendor_data.VendorKey,
                VendorCode = vendor_data.VendorCode,
                VendorName = vendor_data.VendorName,
                VendorDesc = vendor_data.VendorDesc,
                AddedUserID = vendor_data.AuditAddUserId,
                AddedDateTime = vendor_data.AuditAddDatetime,
                UpdateUserID = vendor_data.AuditUpdateUserId,
                UpdateDateTime = vendor_data.AuditUpdateDatetime,
            };
        }

        public VendorData Map(Vendor vendor)
        {
            return new VendorData()
            {
                VendorKey = vendor.VendorKey,
                VendorCode = vendor.VendorCode,
                VendorName = vendor.VendorName,
                VendorDesc = vendor.VendorDesc
            };
        }
    }

} // namespace closer
