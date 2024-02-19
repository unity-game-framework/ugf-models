namespace UGF.Models.Runtime.Collections
{
    public interface ICollectionModel : IModelClearable, IModelCopyable, IModelCloneable
    {
        int GetCount();
    }
}
