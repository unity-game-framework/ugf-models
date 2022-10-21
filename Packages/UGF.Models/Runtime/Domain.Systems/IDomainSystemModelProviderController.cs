using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain.Systems
{
    public interface IDomainSystemModelProviderController : IModelController
    {
        IReadOnlyCollection<Guid> ModelIds { get; }

        bool TryGetControllerId(Guid modelId, out Guid controllerId);
        bool TryGetModelId(Guid controllerId, out Guid modelId);
    }
}
