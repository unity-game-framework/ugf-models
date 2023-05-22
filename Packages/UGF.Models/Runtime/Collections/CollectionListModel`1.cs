using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionListModel<TModel> : ICollectionModel where TModel : IModel
    {
        public int Count { get { return Models.Count; } }
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

        protected virtual void OnClear()
        {
        }
    }
}
