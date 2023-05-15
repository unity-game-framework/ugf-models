using System;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Collections
{
    public delegate void CollectionDictionaryModelChangeHandler<TModel>(CollectionDictionaryModel<TModel> collection, Guid id, TModel model, IContext context) where TModel : IModel;
}
