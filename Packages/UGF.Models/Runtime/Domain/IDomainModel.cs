using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public interface IDomainModel : IModel
    {
        IDictionary<Guid, IModel> Models { get; }
    }
}
