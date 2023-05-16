using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionDictionaryModel<TModel> : ICollectionModel where TModel : IModel
    {
        public int Count { get { return Models.Count; } }
        public Dictionary<Guid, TModel> Models { get; set; } = new Dictionary<Guid, TModel>();

        public void Clear()
        {
            OnClear();

            Models.Clear();
        }

        protected virtual void OnClear()
        {
        }
    }
}
