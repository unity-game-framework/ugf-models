using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public interface IModelController : IController
    {
        void Execute(IModel model, IContext context);
    }
}
