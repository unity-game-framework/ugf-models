namespace UGF.Models.Runtime.Collections
{
    public interface ICollectionModel : IModel
    {
        int Count { get; }

        void Clear();
    }
}
