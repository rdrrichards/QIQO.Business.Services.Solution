namespace QIQO.Business.Engines.Services
{
    //public class LedgerEntityService : ILedgerEntityService, IEntityService<Ledger, LedgerData>
    //{
    //    public Ledger Map(LedgerData ledger_data)
    //    {
    //        return new Ledger()
    //        {
    //            LedgerKey = ledger_data.LedgerKey,
    //            CompanyKey = ledger_data.CompanyKey,
    //            LedgerCode = ledger_data.LedgerCode,
    //            LedgerName = ledger_data.LedgerName,
    //            LedgerDesc = ledger_data.LedgerDesc,
    //            AuditAddUserId = ledger_data.AuditAddUserId,
    //            AuditAddDatetime = ledger_data.AuditAddDatetime,
    //            AuditUpdateUserId = ledger_data.AuditUpdateUserId,
    //            AuditUpdateDatetime = ledger_data.AuditUpdateDatetime,
    //        };
    //    }

    //    public LedgerData Map(Ledger ledger)
    //    {
    //        return new LedgerData()
    //        {
    //            LedgerKey = ledger.LedgerKey,
    //            CompanyKey = ledger.CompanyKey,
    //            LedgerCode = ledger.LedgerCode,
    //            LedgerName = ledger.LedgerName,
    //            LedgerDesc = ledger.LedgerDesc,
    //            AuditAddUserId = ledger.AuditAddUserId,
    //            AuditAddDatetime = ledger.AuditAddDatetime,
    //            AuditUpdateUserId = ledger.AuditUpdateUserId,
    //            AuditUpdateDatetime = ledger.AuditUpdateDatetime,
    //        };
    //    }
    //}

    //public class LedgerTxnEntityService : ILedgerTxnEntityService, IEntityService<LedgerTxn, LedgerTxnData>
    //{
    //    public LedgerTxn Map(LedgerTxnData ledger_txn_data)
    //    {
    //        return new LedgerTxn()
    //        {
    //            LedgerTxnKey = ledger_txn_data.LedgerTxnKey,
    //            LedgerKey = ledger_txn_data.LedgerKey,
    //            TxnComment = ledger_txn_data.TxnComment,
    //            AcctFrom = ledger_txn_data.AcctFrom,
    //            DeptFrom = ledger_txn_data.DeptFrom,
    //            LobFrom = ledger_txn_data.LobFrom,
    //            AcctTo = ledger_txn_data.AcctTo,
    //            DeptTo = ledger_txn_data.DeptTo,
    //            LobTo = ledger_txn_data.LobTo,
    //            TxnNum = ledger_txn_data.TxnNum,
    //            PostDate = ledger_txn_data.PostDate,
    //            EntryDate = ledger_txn_data.EntryDate,
    //            Credit = ledger_txn_data.Credit,
    //            Debit = ledger_txn_data.Debit,
    //            EntityKey = ledger_txn_data.EntityKey,
    //            EntityTypeKey = ledger_txn_data.EntityTypeKey,
    //            AuditAddUserId = ledger_txn_data.AuditAddUserId,
    //            AuditAddDatetime = ledger_txn_data.AuditAddDatetime,
    //            AuditUpdateUserId = ledger_txn_data.AuditUpdateUserId,
    //            AuditUpdateDatetime = ledger_txn_data.AuditUpdateDatetime,
    //        };
    //    }

    //    public LedgerTxnData Map(LedgerTxn ledger_txn)
    //    {
    //        return new LedgerTxnData()
    //        {
    //            LedgerTxnKey = ledger_txn.LedgerTxnKey,
    //            LedgerKey = ledger_txn.LedgerKey,
    //            TxnComment = ledger_txn.TxnComment,
    //            AcctFrom = ledger_txn.AcctFrom,
    //            DeptFrom = ledger_txn.DeptFrom,
    //            LobFrom = ledger_txn.LobFrom,
    //            AcctTo = ledger_txn.AcctTo,
    //            DeptTo = ledger_txn.DeptTo,
    //            LobTo = ledger_txn.LobTo,
    //            TxnNum = ledger_txn.TxnNum,
    //            PostDate = ledger_txn.PostDate,
    //            EntryDate = ledger_txn.EntryDate,
    //            Credit = ledger_txn.Credit,
    //            Debit = ledger_txn.Debit,
    //            EntityKey = ledger_txn.EntityKey,
    //            EntityTypeKey = ledger_txn.EntityTypeKey,
    //            AuditAddUserId = ledger_txn.AuditAddUserId,
    //            AuditAddDatetime = ledger_txn.AuditAddDatetime,
    //            AuditUpdateUserId = ledger_txn.AuditUpdateUserId,
    //            AuditUpdateDatetime = ledger_txn.AuditUpdateDatetime,
    //        };
    //    }
    //}

    //public class PersonEntityService : IPersonEntityService, IEntityService<Person, PersonData>
    //{
    //    public Person Map(PersonData person_data)
    //    {
    //        return new Person()
    //        {
    //            PersonKey = person_data.PersonKey,
    //            PersonCode = person_data.PersonCode,
    //            PersonFirstName = person_data.PersonFirstName,
    //            PersonMi = person_data.PersonMi,
    //            PersonLastName = person_data.PersonLastName,
    //            ParentPersonKey = person_data.ParentPersonKey,
    //            PersonDob = person_data.PersonDob,
    //            AuditAddUserId = person_data.AuditAddUserId,
    //            AuditAddDatetime = person_data.AuditAddDatetime,
    //            AuditUpdateUserId = person_data.AuditUpdateUserId,
    //            AuditUpdateDatetime = person_data.AuditUpdateDatetime,
    //        };
    //    }

    //    public PersonData Map(Person person)
    //    {
    //        return new PersonData()
    //        {
    //            PersonKey = person.PersonKey,
    //            PersonCode = person.PersonCode,
    //            PersonFirstName = person.PersonFirstName,
    //            PersonMi = person.PersonMi,
    //            PersonLastName = person.PersonLastName,
    //            ParentPersonKey = person.ParentPersonKey,
    //            PersonDob = person.PersonDob,
    //            AuditAddUserId = person.AuditAddUserId,
    //            AuditAddDatetime = person.AuditAddDatetime,
    //            AuditUpdateUserId = person.AuditUpdateUserId,
    //            AuditUpdateDatetime = person.AuditUpdateDatetime,
    //        };
    //    }
    //}

    //public class PersonTypeEntityService : IPersonTypeEntityService, IEntityService<PersonType, PersonTypeData>
    //{
    //    public PersonType Map(PersonTypeData person_type_data)
    //    {
    //        return new PersonType()
    //        {
    //            PersonTypeKey = person_type_data.PersonTypeKey,
    //            PersonTypeCategory = person_type_data.PersonTypeCategory,
    //            PersonTypeCode = person_type_data.PersonTypeCode,
    //            PersonTypeName = person_type_data.PersonTypeName,
    //            PersonTypeDesc = person_type_data.PersonTypeDesc,
    //            AuditAddUserId = person_type_data.AuditAddUserId,
    //            AuditAddDatetime = person_type_data.AuditAddDatetime,
    //            AuditUpdateUserId = person_type_data.AuditUpdateUserId,
    //            AuditUpdateDatetime = person_type_data.AuditUpdateDatetime,
    //        };
    //    }

    //    public PersonTypeData Map(PersonType person_type)
    //    {
    //        return new PersonTypeData()
    //        {
    //            PersonTypeKey = person_type.PersonTypeKey,
    //            PersonTypeCategory = person_type.PersonTypeCategory,
    //            PersonTypeCode = person_type.PersonTypeCode,
    //            PersonTypeName = person_type.PersonTypeName,
    //            PersonTypeDesc = person_type.PersonTypeDesc,
    //            AuditAddUserId = person_type.AuditAddUserId,
    //            AuditAddDatetime = person_type.AuditAddDatetime,
    //            AuditUpdateUserId = person_type.AuditUpdateUserId,
    //            AuditUpdateDatetime = person_type.AuditUpdateDatetime,
    //        };
    //    }
    //}
}
