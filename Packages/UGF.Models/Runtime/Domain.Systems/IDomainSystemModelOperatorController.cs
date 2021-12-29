using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public interface IDomainSystemModelOperatorController : IController
    {
        void Add(IDomainSystemModel systemModel, IModel model, IContext context);
        bool Remove(IDomainSystemModel systemModel, IModel model, IContext context);
    }
}
