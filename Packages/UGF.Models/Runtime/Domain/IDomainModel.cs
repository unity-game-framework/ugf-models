using System;
using System.Collections.Generic;
using UGF.Models.Runtime.Collections;

namespace UGF.Models.Runtime.Domain
{
    public interface IDomainModel : ICollectionModel
    {
        IDictionary<Guid, IModel> Models { get; }
    }
}
