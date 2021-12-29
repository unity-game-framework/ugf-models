using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public interface IDomainModel : IModel
    {
        IReadOnlyDictionary<string, IModel> Models { get; }

        void Add(string id, IModel model);
        bool Remove(string id);
        void Clear();
        bool TryGet(string id, out IModel model);
    }
}
