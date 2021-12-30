using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelExecuteControllerAsync : ModelControllerAsyncDescribed<DomainModelExecuteControllerDescription, IDomainModel>
    {
        public IReadOnlyList<(string ModelId, IModelControllerAsync Controller)> Controllers { get; }

        private readonly List<(string ModelId, IModelControllerAsync Controller)> m_controllers = new List<(string ModelId, IModelControllerAsync Controller)>();

        public DomainModelExecuteControllerAsync(DomainModelExecuteControllerDescription description, IApplication application) : base(description, application)
        {
            Controllers = new ReadOnlyCollection<(string ModelId, IModelControllerAsync Controller)>(m_controllers);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            var controllerModule = Application.GetModule<IControllerModule>();

            for (int i = 0; i < Description.ModelControllerIds.Count; i++)
            {
                (string modelId, string controllerId) = Description.ModelControllerIds[i];

                var controller = controllerModule.Provider.Get<IModelControllerAsync>(controllerId);

                m_controllers.Add((modelId, controller));
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_controllers.Clear();
        }

        protected override async Task OnExecuteAsync(IDomainModel domainModel, IContext context)
        {
            for (int i = 0; i < m_controllers.Count; i++)
            {
                (string modelId, IModelControllerAsync controller) = m_controllers[i];

                IModel model = domainModel.Get(modelId);

                await controller.ExecuteAsync(model, context);
            }
        }
    }
}
