using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain.Systems
{
    public interface IDomainSystemModelProviderController : IModelController
    {
        IReadOnlyCollection<string> ModelIds { get; }

        bool TryGetControllerId(string modelId, out string controllerId);
        bool TryGetModelId(string controllerId, out string modelId);
    }
}
