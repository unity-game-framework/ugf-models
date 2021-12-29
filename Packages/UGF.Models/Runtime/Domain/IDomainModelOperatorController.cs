using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public interface IDomainModelOperatorController : IController
    {
        string GenerateId();
        string Add(IDomainModel domainModel, IModel model, IContext context);
        void Add(IDomainModel domainModel, string modelId, IModel model, IContext context);
        bool Remove(IDomainModel domainModel, IModel model, IContext context);
        bool Remove(IDomainModel domainModel, string modelId, IContext context);
        string GetId(IModel model, IContext context);
    }
}
