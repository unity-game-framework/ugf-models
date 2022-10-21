using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public interface IDomainModel : IModel
    {
        IReadOnlyDictionary<Guid, IModel> Models { get; }

        void Add(Guid id, IModel model);
        bool Remove(Guid id);
        void Clear();
        bool TryGet(Guid id, out IModel model);
    }
}
