using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelGroupModel : IModel
    {
        public Dictionary<Guid, Guid> ModelIds { get; set; } = new Dictionary<Guid, Guid>();

        public void Clear()
        {
            OnClear();
        }

        public int GetCount()
        {
            return ModelIds.Count;
        }

        public void CopyFrom(IModel model)
        {
            if (model is not DomainModelGroupModel collection) throw new ArgumentException($"Model type must be of '{typeof(DomainModelGroupModel)}', but was '{model}'.");

            OnCopyFrom(collection);
        }

        protected virtual void OnClear()
        {
            ModelIds.Clear();
        }

        protected virtual void OnCopyFrom(DomainModelGroupModel collection)
        {
            foreach ((Guid key, Guid value) in collection.ModelIds)
            {
                ModelIds.Add(key, value);
            }
        }
    }
}
