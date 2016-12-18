using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public enum QIQOEntityType
    {
        //entity_type_key	entity_type_code	entity_type_name
        //1	            COMP	            Company
        //2	            PERS	            Person
        //3	            ACCT	            Account
        //4	            PRD	                Product
        //5	            ORD	                Order
        //6	            ORD_ITEM	        Order Item
        //7	            INV	                Invoice
        //8	            INV_ITEM	        Invoice Item
        //9	            GL	                General Ledger
        //10	            GL_ITEM	            General Ledger Txn
        //11	            VEND	            Vendor

        //[EnumMember]
        //Unknown = 0,
        [EnumMember]
        Company = 1,
        [EnumMember]
        Person = 2,
        [EnumMember]
        Account = 3,
        [EnumMember]
        Product = 4,
        [EnumMember]
        Order = 5,
        [EnumMember]
        OrderItem = 6,
        [EnumMember]
        Invoice = 7,
        [EnumMember]
        InvoiceItem = 8,
        [EnumMember]
        GeneralLedger = 9,
        [EnumMember]
        GeneralLedgerTxn = 10,
        [EnumMember]
        Vendor = 11,
        [EnumMember]
        Manager = 12,
        [EnumMember]
        CoWorker = 13
    }

    [DataContract]
    public enum QIQOEntityNumberType
    {
        [EnumMember]
        InvoiceNumber = 1,
        [EnumMember]
        OrderNumber = 2,
        [EnumMember]
        EmployeeNumber = 3,
        [EnumMember]
        AccountNumber = 4,
        [EnumMember]
        VendorNumber = 5,
        [EnumMember]
        ContactNumber = 6
    }

    [DataContract]
    public enum QIQOAccountType
    {
        //[EnumMember]
        //Unknown = 0,
        [EnumMember]
        TestAccount = 1,
        [EnumMember]
        Business = 2,
        [EnumMember]
        Individual = 3
    }

    [DataContract]
    public enum QIQOAddressType
    {
        //[EnumMember]
        //Unknown = 0,
        [EnumMember]
        Mailing = 1,
        [EnumMember]
        Shipping = 2,
        [EnumMember]
        Billing = 3
    }

    [DataContract]
    public enum QIQOAttributeType
    {
        //[EnumMember]
        //Unknown = 0,

        [EnumMember]
        Account_INVNUM = 1,
        [EnumMember]
        Account_INVNUMPAT = 2,
        [EnumMember]
        Account_ORDNUM = 3,
        [EnumMember]
        Account_ORDNUMPAT = 4,
        [EnumMember]
        Account_URLCOM = 19,
        [EnumMember]
        Account_URLINFO = 18,

        [EnumMember]
        AccountEmployee_EMAILCO = 21,
        [EnumMember]
        AccountEmployee_EMAILPER = 22,
        [EnumMember]
        AccountEmployee_LANG = 23,

        [EnumMember]
        AccountRepresentative_REGION1 = 24,
        [EnumMember]
        AccountRepresentative_REGION2 = 25,
        [EnumMember]
        AccountRepresentative_REGION3 = 26,

        [EnumMember]
        Company_ACCTNUM = 8,
        [EnumMember]
        Company_ACCTNUMPAT = 9,
        [EnumMember]
        Company_EMPNUM = 10,
        [EnumMember]
        Company_EMPNUMPAT = 11,
        [EnumMember]
        Company_URLCOM = 17,
        [EnumMember]
        Company_URLINFO = 16,
        [EnumMember]
        Company_VENDORNUM = 12,
        [EnumMember]
        Company_VENDORNUMP = 13,

        [EnumMember]
        Employee_DEFAULTCO = 7,
        [EnumMember]
        Employee_LANG = 20,
        [EnumMember]
        Employee_LOGIN = 5,
        [EnumMember]
        Employee_SSN = 6,

        [EnumMember]
        Product_PRODBASE = 30,
        [EnumMember]
        Product_PRODCOST = 31,
        [EnumMember]
        Product_PRODDFQTY = 32,
        [EnumMember]
        Product_INCACCT = 53,
        [EnumMember]
        Product_EXPACCT = 54,

        [EnumMember]
        SalesRepresentative_REGION1 = 27,
        [EnumMember]
        SalesRepresentative_REGION2 = 28,
        [EnumMember]
        SalesRepresentative_REGION3 = 29,

        [EnumMember]
        GeneralContact_PHN_HOME = 33,
        [EnumMember]
        GeneralContact_PHN_CELL = 34,
        [EnumMember]
        GeneralContact_PHN_WORK = 35,
        [EnumMember]
        GeneralContact_PHN_PAGR = 36,
        [EnumMember]
        GeneralContact_PHN_FAX = 37,
        [EnumMember]
        GeneralContact_PHN_OTH = 38,
        [EnumMember]
        GeneralContact_EMAIL_PERS = 39,
        [EnumMember]
        GeneralContact_EMAIL_WRKP = 40,
        [EnumMember]
        GeneralContact_EMAIL_WRKS = 41,
        [EnumMember]
        GeneralContact_SKYPE = 42,
        [EnumMember]
        GeneralContact_FACEB_URL = 43,
        [EnumMember]
        GeneralContact_EM_OPTOUT = 44,

        [EnumMember]
        CompanyContact_CNCT_MAIN = 45,
        [EnumMember]
        CompanyContact_CNCT_SEC = 46,
        [EnumMember]
        CompanyContact_CNCT_OTH = 47,

        [EnumMember]
        AccountContact_CNCT_MAIN = 48,
        [EnumMember]
        AccountContact_CNCT_SEC = 49,
        [EnumMember]
        AccountContact_CNCT_OTH = 50,
    }

    [DataContract]
    public enum QIQOAttributeDataType
    {
        [EnumMember]
        Number = 1,
        [EnumMember]
        String = 2,
        [EnumMember]
        Money = 3
    }

    [DataContract]
    public enum QIQOInvoiceStatus
    {
        //Unknown = 0,
        [EnumMember]
        New = 1,
        [EnumMember]
        InProcess = 2,
        [EnumMember]
        PendingPayment = 3,
        [EnumMember]
        Complete = 4,
        [EnumMember]
        Canceled = 5
    }

    [DataContract]
    public enum QIQOInvoiceItemStatus
    {
        //Unknown = 0,
        [EnumMember]
        New = 6,
        [EnumMember]
        InProcess = 7,
        [EnumMember]
        PendingPayment = 8,
        [EnumMember]
        Complete = 9,
        [EnumMember]
        Canceled = 10
    }

    [DataContract]
    public enum QIQOOrderStatus
    {
        //Unknown = 0,
        [EnumMember]
        Scheduled = 1,
        [EnumMember]
        Open = 2,
        [EnumMember]
        InProcess = 3,
        [EnumMember]
        Fulfilled = 4,
        [EnumMember]
        PendingPayment = 5,
        [EnumMember]
        Complete = 6,
        [EnumMember]
        Canceled = 13
    }

    [DataContract]
    public enum QIQOOrderItemStatus
    {
        //Unknown = 0,
        [EnumMember]
        Scheduled = 7,
        [EnumMember]
        Open = 8,
        [EnumMember]
        InProcess = 9,
        [EnumMember]
        Fulfilled = 10,
        [EnumMember]
        PendingPayment = 11,
        [EnumMember]
        Complete = 12,
        [EnumMember]
        Canceled = 14
    }

    [DataContract]
    public enum QIQOPersonType
    {
        [EnumMember]
        EmployeeHourly = 1,
        [EnumMember]
        EmployeeSalary = 2,
        [EnumMember]
        SalesRepresentative = 3,
        [EnumMember]
        AccountRepresentative = 4,
        [EnumMember]
        AccountOwner = 5,
        [EnumMember]
        AccountEmployee = 6,
        [EnumMember]
        AccountContact = 7,
        [EnumMember]
        VendorRepresentative = 8
    }

    [DataContract]
    public enum QIQOProductType
    {
        //Unknown = 0,
        [EnumMember]
        Sweet9 = 1,
        [EnumMember]
        Sweet10 = 2,
        [EnumMember]
        Sweet6 = 3,
        [EnumMember]
        Sweet8 = 4,
        [EnumMember]
        Savory4 = 5,
        [EnumMember]
        Savory6 = 6,
        [EnumMember]
        Savory8 = 7,
        [EnumMember]
        SweetMini = 8
    }

    [DataContract]
    public enum QIQOContactType
    {
        [EnumMember]
        AccountContact = 1, //ACNT
        [EnumMember]
        CellPhone = 2, //PHNCELL
        [EnumMember]
        HomePhone = 3, //PHNHOME
        [EnumMember]
        BusinessPhone = 4, //PHNBUS
        [EnumMember]
        WorkPhone = 5, //PHNWORK
        [EnumMember]
        OtherPhone = 6, //PHNOTH1
        [EnumMember]
        WorkFax = 7, //FAXWORK
        [EnumMember]
        PersonalFax = 8, //FAXPERS
        [EnumMember]
        WorkEmail = 9, //EMAILWRK
        [EnumMember]
        PersonalEmail = 10, //EMAILPERS
        [EnumMember]
        OtherEmail = 11, //EMAILOTH1
        [EnumMember]
        InstanceMessenger = 12 // IM1
    }

    [DataContract]
    public enum QIQOCommentType
    {
        [EnumMember]
        Public = 1,
        [EnumMember]
        Private = 2
    }
}
