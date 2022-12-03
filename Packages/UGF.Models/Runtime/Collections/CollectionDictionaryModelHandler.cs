using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Collections
{
    public delegate void CollectionDictionaryModelHandler<TModel>(CollectionDictionaryModel<TModel> collection, IContext context) where TModel : class, IModel;
}
