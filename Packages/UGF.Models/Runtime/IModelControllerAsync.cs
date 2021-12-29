using System.Threading.Tasks;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public interface IModelControllerAsync : IController
    {
        Task ExecuteAsync(IModel model, IContext context);
    }
}
