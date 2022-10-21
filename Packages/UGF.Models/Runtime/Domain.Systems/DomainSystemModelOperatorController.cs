using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public class DomainSystemModelOperatorController : ControllerDescribed<DomainSystemModelOperatorControllerDescription>, IDomainSystemModelOperatorController
    {
        protected IDomainModelOperatorController DomainModelOperatorController { get; }

        public DomainSystemModelOperatorController(DomainSystemModelOperatorControllerDescription description, IApplication application) : base(description, application)
        {
            DomainModelOperatorController = Application.GetController<IDomainModelOperatorController>(Description.DomainModelOperatorControllerId);
        }

        public void Add(IDomainSystemModel systemModel, IModel model, IContext context)
        {
            if (systemModel == null) throw new ArgumentNullException(nameof(systemModel));

            Guid id = DomainModelOperatorController.GetId(model, context);

            systemModel.ModelIds.Add(id);
        }

        public bool Remove(IDomainSystemModel systemModel, IModel model, IContext context)
        {
            if (systemModel == null) throw new ArgumentNullException(nameof(systemModel));

            Guid id = DomainModelOperatorController.GetId(model, context);

            return systemModel.ModelIds.Remove(id);
        }
    }
}
