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
        }

        public int GetCount()
        {
            return Models.Count;
        }

        public void CopyFrom(IModel model)
        {
            if (model is not CollectionDictionaryModel<TModel> collection) throw new ArgumentException($"Model type must be of '{typeof(CollectionDictionaryModel<TModel>)}', but was '{model}'.");

            OnCopyFrom(collection);
        }

        public IModel Clone()
        {
            return OnClone();
        }

        protected virtual void OnClear()
        {
            Models.Clear();
        }

        protected virtual void OnCopyFrom(CollectionDictionaryModel<TModel> collection)
        {
            foreach ((Guid id, TModel model) in collection.Models)
            {
                Models.Add(id, model);
            }
        }

        protected virtual IModel OnClone()
        {
            return ModelUtility.CreateCopy(this, model => new CollectionDictionaryModel<TModel>(model.Models.Count));
        }
    }
}
