using System;
using System.Linq;
using System.Collections.Generic;

namespace QIQO.Common.Contracts
{
    public interface IIdentityEntity
    {
        string EntityRowKey { get; set; }
    }
}