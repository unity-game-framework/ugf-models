using System.Collections;

namespace UGF.Models.Runtime.Collections
{
    public interface ICollectionModel : IModel
    {
        ICollection Items { get; }
    }
}
