using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModel : IDomainModel
    {
        public Dictionary<Guid, IModel> Models { get; set; } = new Dictionary<Guid, IModel>();

        IReadOnlyDictionary<Guid, IModel> IDomainModel.Models { get { return Models; } }

        public void Add(Guid id, IModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            Models.Add(id, model);
        }

        public bool Remove(Guid id)
        {
            return Models.Remove(id);
        }

        public void Clear()
        {
            Models.Clear();
        }

        public bool TryGet(Guid id, out IModel model)
        {
            return Models.TryGetValue(id, out model);
        }
    }
}
