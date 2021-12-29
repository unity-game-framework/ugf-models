using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public abstract class ModelControllerAsync : ControllerBase, IModelControllerAsync
    {
        protected ModelControllerAsync(IApplication application) : base(application)
        {
        }

        public Task ExecuteAsync(IModel model, IContext context)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            return OnExecuteAsync(model, context);
        }

        protected abstract Task OnExecuteAsync(IModel model, IContext context);
    }
}
