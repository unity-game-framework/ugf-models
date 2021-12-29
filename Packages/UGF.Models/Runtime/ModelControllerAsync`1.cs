using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public abstract class ModelControllerAsync<TModel> : ModelControllerAsync
    {
        protected ModelControllerAsync(IApplication application) : base(application)
        {
        }

        protected override Task OnExecuteAsync(IModel model, IContext context)
        {
            return OnExecuteAsync((TModel)model, context);
        }

        protected abstract Task OnExecuteAsync(TModel model, IContext context);
    }
}
