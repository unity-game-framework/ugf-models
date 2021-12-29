using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public abstract class ModelControllerDescribed<TDescription, TModel> : ModelControllerDescribed<TDescription>
        where TDescription : class, IControllerDescription
        where TModel : IModel
    {
        protected ModelControllerDescribed(TDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnExecute(IModel model, IContext context)
        {
            OnExecute((TModel)model, context);
        }

        protected abstract void OnExecute(TModel model, IContext context);
    }
}
