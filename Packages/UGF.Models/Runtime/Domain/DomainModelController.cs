using System.Collections.Generic;
using System.Collections.ObjectModel;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelController : ModelControllerDescribed<DomainModelControllerDescription, IDomainModel>
    {
        public IReadOnlyList<(GlobalId ModelId, IModelController Controller)> Controllers { get; }

        private readonly List<(GlobalId ModelId, IModelController Controller)> m_controllers = new List<(GlobalId ModelId, IModelController Controller)>();

        public DomainModelController(DomainModelControllerDescription description, IApplication application) : base(description, application)
        {
            Controllers = new ReadOnlyCollection<(GlobalId ModelId, IModelController Controller)>(m_controllers);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            for (int i = 0; i < Description.ModelControllerIds.Count; i++)
            {
                (GlobalId modelId, GlobalId controllerId) = Description.ModelControllerIds[i];

                var controller = Application.GetController<IModelController>(controllerId);

                m_controllers.Add((modelId, controller));
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_controllers.Clear();
        }

        protected override void OnExecute(IDomainModel domainModel, IContext context)
        {
            for (int i = 0; i < m_controllers.Count; i++)
            {
                (GlobalId modelId, IModelController controller) = m_controllers[i];

                IModel model = domainModel.Get(modelId);

                controller.Execute(model, context);
            }
        }
    }
}
