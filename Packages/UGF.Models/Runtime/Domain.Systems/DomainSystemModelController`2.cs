using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public abstract class DomainSystemModelController<TDescription, TModel> : DomainSystemModelController<TDescription>
        where TDescription : class, IControllerDescription
        where TModel : IModel
    {
        protected DomainSystemModelController(TDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnExecute(IDomainSystemModel systemModel, Guid id, IModel model, IContext context)
        {
            OnExecute(systemModel, id, (TModel)model, context);
        }

        protected abstract void OnExecute(IDomainSystemModel systemModel, Guid id, TModel model, IContext context);
    }
}
