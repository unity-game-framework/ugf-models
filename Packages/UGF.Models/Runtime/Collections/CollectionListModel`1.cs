using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionListModel<TModel> : ICollectionModel where TModel : IModel
    {
        public List<TModel> Models { get; set; }

        public CollectionListModel(int capacity = 4)
        {
            Models = new List<TModel>(capacity);
        }

        public void Clear()
        {
            OnClear();
        }

        public int GetCount()
        {
            return Models.Count;
        }

        public void CopyFrom(IModel model)
        {
            if (model is not CollectionListModel<TModel> collection) throw new ArgumentException($"Model type must be of '{typeof(CollectionListModel<TModel>)}', but was '{model}'.");

            OnCopyFrom(collection);
        }

        protected virtual void OnClear()
        {
            Models.Clear();
        }

        protected virtual void OnCopyFrom(CollectionListModel<TModel> collection)
        {
            for (int i = 0; i < collection.Models.Count; i++)
            {
                Models.Add(collection.Models[i]);
            }
        }
    }
}
