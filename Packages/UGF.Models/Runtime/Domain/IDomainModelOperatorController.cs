using System;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public interface IDomainModelOperatorController : IController
    {
        Guid GenerateId();
        Guid Add(IDomainModel domainModel, IModel model, IContext context);
        void Add(IDomainModel domainModel, Guid modelId, IModel model, IContext context);
        bool Remove(IDomainModel domainModel, IModel model, IContext context);
        bool Remove(IDomainModel domainModel, Guid modelId, IContext context);
        Guid GetId(IModel model, IContext context);
        bool TryGetId(IModel model, IContext context, out Guid id);
    }
}
