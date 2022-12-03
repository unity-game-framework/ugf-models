using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Collections
{
    public delegate void CollectionListModelClearHandler<TModel>(CollectionListModel<TModel> collection, IContext context) where TModel : class, IModel;
}
