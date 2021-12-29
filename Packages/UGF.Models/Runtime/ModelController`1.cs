using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime
{
    public abstract class ModelController<TModel> : ModelController where TModel : IModel
    {
        protected ModelController(IApplication application) : base(application)
        {
        }

        protected override void OnExecute(IModel model, IContext context)
        {
            OnExecute((TModel)model, context);
        }

        protected abstract void OnExecute(TModel model, IContext context);
    }
}
