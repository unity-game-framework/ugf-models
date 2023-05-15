using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Collections
{
    public delegate void CollectionListModelChangeHandler<TModel>(CollectionListModel<TModel> collection, int index, TModel model, IContext context) where TModel : IModel;
}
