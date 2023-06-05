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
