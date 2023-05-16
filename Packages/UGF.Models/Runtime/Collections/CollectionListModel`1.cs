using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionListModel<TModel> : ICollectionModel where TModel : IModel
    {
        public int Count { get { return Models.Count; } }
        public List<TModel> Models { get; set; } = new List<TModel>();

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
