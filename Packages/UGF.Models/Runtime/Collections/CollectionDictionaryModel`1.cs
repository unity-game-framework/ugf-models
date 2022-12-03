using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionDictionaryModel<TModel> : IModel where TModel : class, IModel
    {
        public Dictionary<Guid, TModel> Models { get; set; } = new Dictionary<Guid, TModel>();
    }
}
