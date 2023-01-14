using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Relations
{
    public class RelationCollectionModel<TModel> : Dictionary<Guid, TModel> where TModel : class, IModel
    {
    }
}
