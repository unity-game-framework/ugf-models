namespace UGF.Models.Runtime.Collections
{
    public delegate void CollectionListModelChangeHandler<TModel>(CollectionListModel<TModel> collection, int index, TModel model) where TModel : class, IModel;
}
