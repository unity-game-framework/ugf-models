using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Models.Runtime
{
    public interface IModelContainer
    {
        IReadOnlyDictionary<GlobalId, IModel> Models { get; }
    }
}
