using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public abstract class DomainSystemModelController<TDescription, TSystemModel, TModel> : DomainSystemModelController<TDescription, TModel>
        where TDescription : class, IControllerDescription
        where TSystemModel : class, IDomainSystemModel
        where TModel : IModel
    {
        protected DomainSystemModelController(TDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnExecute(IDomainSystemModel systemModel, Guid id, TModel model, IContext context)
        {
            OnExecute((TSystemModel)systemModel, id, model, context);
        }

        protected abstract void OnExecute(TSystemModel systemModel, Guid id, TModel model, IContext context);
    }
}
