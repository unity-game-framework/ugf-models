using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionListModel<TModel> : IModel where TModel : class, IModel
    {
        public List<TModel> Models { get; set; } = new List<TModel>();
    }
}
