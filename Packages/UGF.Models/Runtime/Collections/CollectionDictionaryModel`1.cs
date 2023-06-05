using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionDictionaryModel<TModel> : ICollectionModel where TModel : IModel
    {
        public Dictionary<Guid, TModel> Models { get; set; }

        public CollectionDictionaryModel(int capacity = 4)
        {
            Models = new Dictionary<Guid, TModel>(capacity);
        }

        public void Clear()
        {
            OnClear();

            Models.Clear();
        }

        public int GetCount()
        {
            return Models.Count;
        }

        protected virtual void OnClear()
        {
        }
    }
}
