using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public abstract class ModelControllerAsyncDescribed<TDescription> : ControllerDescribed<TDescription>, IModelControllerAsync where TDescription : class, IControllerDescription
    {
        protected ModelControllerAsyncDescribed(TDescription description, IApplication application) : base(description, application)
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
