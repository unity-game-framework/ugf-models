using System.Collections.Generic;

namespace UGF.Models.Runtime
{
    public interface IModelContainer
    {
        IReadOnlyDictionary<string, IModel> Models { get; }
    }
}
