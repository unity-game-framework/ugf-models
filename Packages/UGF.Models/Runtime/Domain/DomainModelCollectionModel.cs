using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelCollectionModel : IModelClearable, IModelCopyable
    {
        public List<Guid> ModelIds { get; set; } = new List<Guid>();

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
            if (model is not DomainModelCollectionModel collection) throw new ArgumentException($"Model type must be of '{typeof(DomainModelCollectionModel)}', but was '{model}'.");

            OnCopyFrom(collection);
        }

        protected virtual void OnClear()
        {
            ModelIds.Clear();
        }

        protected virtual void OnCopyFrom(DomainModelCollectionModel collection)
        {
            for (int i = 0; i < collection.ModelIds.Count; i++)
            {
                ModelIds.Add(collection.ModelIds[i]);
            }
        }
    }
}
