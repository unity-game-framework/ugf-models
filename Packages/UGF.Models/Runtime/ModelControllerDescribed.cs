using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public abstract class ModelControllerDescribed<TDescription> : ControllerDescribed<TDescription>, IModelController where TDescription : class, IControllerDescription
    {
        protected ModelControllerDescribed(TDescription description, IApplication application) : base(description, application)
        {
        }

        public void Execute(IModel model, IContext context)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));
        }

        protected abstract void OnExecute(IModel model, IContext context);
    }
}
