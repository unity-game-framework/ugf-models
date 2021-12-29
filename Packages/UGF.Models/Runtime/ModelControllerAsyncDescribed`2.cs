using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public abstract class ModelControllerAsyncDescribed<TDescription, TModel> : ModelControllerAsyncDescribed<TDescription>
        where TDescription : class, IControllerDescription
        where TModel : IModel
    {
        protected ModelControllerAsyncDescribed(TDescription description, IApplication application) : base(description, application)
        {
        }

        protected override Task OnExecuteAsync(IModel model, IContext context)
        {
            return OnExecuteAsync((TModel)model, context);
        }

        protected abstract Task OnExecuteAsync(TModel model, IContext context);
    }
}
