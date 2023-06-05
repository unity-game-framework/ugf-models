namespace UGF.Models.Runtime.Collections
{
    public interface ICollectionModel : IModel
    {
        void Clear();
        int GetCount();
    }
}
