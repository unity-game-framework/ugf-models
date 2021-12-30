using System.Collections.Generic;
using System.Collections.ObjectModel;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelExecuteController : ModelControllerDescribed<DomainModelExecuteControllerDescription, IDomainModel>
    {
        public IReadOnlyList<(string ModelId, IModelController Controller)> Controllers { get; }

        private readonly List<(string ModelId, IModelController Controller)> m_controllers = new List<(string ModelId, IModelController Controller)>();

        public DomainModelExecuteController(DomainModelExecuteControllerDescription description, IApplication application) : base(description, application)
        {
            Controllers = new ReadOnlyCollection<(string ModelId, IModelController Controller)>(m_controllers);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            var controllerModule = Application.GetModule<IControllerModule>();

            for (int i = 0; i < Description.ModelControllerIds.Count; i++)
            {
                (string modelId, string controllerId) = Description.ModelControllerIds[i];

                var controller = controllerModule.Provider.Get<IModelController>(controllerId);

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
                (string modelId, IModelController controller) = m_controllers[i];

                IModel model = domainModel.Get(modelId);

                controller.Execute(model, context);
            }
        }
    }
}
