using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModel : IDomainModel
    {
        public Dictionary<string, IModel> Models { get; set; } = new Dictionary<string, IModel>();

        IReadOnlyDictionary<string, IModel> IDomainModel.Models { get { return Models; } }

        public void Add(string id, IModel model)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));

            Models.Add(id, model);
        }

        public bool Remove(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return Models.Remove(id);
        }

        public void Clear()
        {
            Models.Clear();
        }

        public bool TryGet(string id, out IModel model)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return Models.TryGetValue(id, out model);
        }
    }
}
