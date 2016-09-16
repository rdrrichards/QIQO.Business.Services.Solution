namespace QIQO.Business.Engines
{
    //public class VendorBusinessEngine : EngineBase, IVendorBusinessEngine
    //{
    ////    //private IVendorRepository vendor_repo;
    ////    private IDataRepositoryFactory _data_repository_factory;
    ////    private IBusinessEngineFactory _business_engine_factory;

    ////    public VendorBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact) //
    ////    {
    ////        _data_repository_factory = data_repo_fact;
    ////        _business_engine_factory = bus_eng_fact;
    ////    }

    ////    public bool VendorDelete(Vendor vendor)
    ////    {
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IVendorRepository vendor_repo = _data_repository_factory.GetDataRepository<IVendorRepository>();
    ////            VendorData vendor = MapVendorToVendorData(vendor);

    ////            vendor_repo.Delete(vendor);
    ////            return true;
    ////        });
    ////    }

    ////    public int VendorSave(Vendor vendor)
    ////    {
    ////        if (vendor == null)
    ////            throw new ArgumentNullException("vendor", "The vendor parameter is invalid");

    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IVendorRepository vendor_repo = _data_repository_factory.GetDataRepository<IVendorRepository>();

    ////            int vendor_key;
    ////            VendorData prod_data = MapVendorToVendorData(vendor);

    ////            vendor_key = vendor_repo.Insert(prod_data);

    ////            return vendor_key;
    ////        });
    ////    }
    ////    public Vendor GetVendorByCode(string vendor_code, Company company)
    ////    {
    ////        return GetVendorByCode(vendor_code, company.CompanyCode);
    ////    }

    ////    public Vendor GetVendorByCode(string vendor_code, string company_code)
    ////    {
    ////        Log.Info("Accessing VendorBusinessEngine GetVendorByCode function");
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IVendorRepository vendor_repo = _data_repository_factory.GetDataRepository<IVendorRepository>();
    ////            VendorData vendor_data = vendor_repo.GetByCode(vendor_code, company_code);
    ////            Log.Info("VendorBusinessEngine GetVendorByCode function completed");

    ////            if (vendor_data.VendorKey != 0)
    ////            {
    ////                Vendor vendor = MapVendorDataToVendor(vendor_data);

    ////                return vendor;
    ////            }
    ////            else
    ////            {
    ////    //Log.Info("{0} VendorBusinessEngine Error: Unable to find vendor with key {1}", vendor_key);
    ////    //FaultException ex = new FaultException(string.Format("Vendor with login {0} is not in database", vendor_key));
    ////    //throw ex;
    ////    NotFoundException ex = new NotFoundException(string.Format("Vendor with code {0} is not in database", vendor_code));
    ////                throw new FaultException<NotFoundException>(ex, ex.Message);
    ////            }
    ////        });
    ////    }
    ////    public Vendor GetVendorByID(int vendor_key)
    ////    {

    ////        //if (Unity.Container != null)
    ////        //{
    ////        //    foreach (ContainerRegistration reg in Unity.Container.Registrations)
    ////        //        Log.Info(reg.RegisteredType.ToString());
    ////        //}
    ////        //Log.Info("{0} Accessing VendorBusinessEngine GetVendorByID function");

    ////        Log.Info("Accessing VendorBusinessEngine GetVendorByID function");
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IVendorRepository vendor_repo = _data_repository_factory.GetDataRepository<IVendorRepository>();
    ////            VendorData vendor_data = vendor_repo.GetByID(vendor_key);
    ////            Log.Info("VendorBusinessEngine GetByID function completed");

    ////            if (vendor_data.VendorKey != 0)
    ////            {
    ////                Vendor vendor = MapVendorDataToVendor(vendor_data);

    ////                return vendor;
    ////            }
    ////            else
    ////            {
    ////    //Log.Info("{0} VendorBusinessEngine Error: Unable to find vendor with key {1}", vendor_key);
    ////    //FaultException ex = new FaultException(string.Format("Vendor with login {0} is not in database", vendor_key));
    ////    //throw ex;
    ////    NotFoundException ex = new NotFoundException(string.Format("Vendor with key {0} is not in database", vendor_key));
    ////                throw new FaultException<NotFoundException>(ex, ex.Message);
    ////            }
    ////        });
    ////    }

    ////    public List<Vendor> GetVendorsByCompany(Company company)
    ////    {
    ////        if (company == null)
    ////            throw new ArgumentNullException(nameof(company));

    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IVendorRepository vendor_repo = _data_repository_factory.GetDataRepository<IVendorRepository>();
    ////// _business_engine_factory
    ////List<Vendor> vendors = new List<Vendor>();
    ////            CompanyData comp = new CompanyData();
    ////            comp.CompanyKey = company.CompanyKey;

    ////            IEnumerable<VendorData> vendors = vendor_repo.GetAll(comp);

    ////            foreach (VendorData vendor in vendors)
    ////            {
    ////                Vendor vendor = MapVendorDataToVendor(vendor);
    ////                vendors.Add(vendor);
    ////            }
    ////            return vendors;
    ////        });
    ////    }
    ////    private Vendor MapVendorDataToVendor(VendorData vendor_data)
    ////    {
    ////        Vendor vendor = new Vendor()
    ////        {
    ////            AddedUserID = vendor_data.AuditAddUserId,
    ////            AddedDateTime = vendor_data.AuditAddDatetime,
    ////            UpdateUserID = vendor_data.AuditUpdateUserId,
    ////            UpdateDateTime = vendor_data.AuditUpdateDatetime
    ////        };

    ////        return vendor;
    ////    }
    ////    private VendorData MapVendorToVendorData(Vendor vendor)
    ////    {
    ////        VendorData vendor_data = new VendorData()
    ////        {

    ////        };

    ////        return vendor_data;
    ////    }
    //}
}