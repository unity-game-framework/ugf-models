using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Collections
{
    public delegate void CollectionDictionaryModelClearHandler<TModel>(CollectionDictionaryModel<TModel> collection, IContext context) where TModel : IModel;
}
