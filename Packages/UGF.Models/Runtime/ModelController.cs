using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public abstract class ModelController : ControllerBase, IModelController
    {
        protected ModelController(IApplication application) : base(application)
        {
        }

        public void Execute(IModel model, IContext context)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnExecute(model, context);
        }

        protected abstract void OnExecute(IModel model, IContext context);
    }
}
