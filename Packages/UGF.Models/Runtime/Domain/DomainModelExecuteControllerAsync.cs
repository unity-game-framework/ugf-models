using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelExecuteControllerAsync : ModelControllerAsyncDescribed<DomainModelExecuteControllerDescription, IDomainModel>
    {
        public IReadOnlyList<(GlobalId ModelId, IModelControllerAsync Controller)> Controllers { get; }

        private readonly List<(GlobalId ModelId, IModelControllerAsync Controller)> m_controllers = new List<(GlobalId ModelId, IModelControllerAsync Controller)>();

        public DomainModelExecuteControllerAsync(DomainModelExecuteControllerDescription description, IApplication application) : base(description, application)
        {
            Controllers = new ReadOnlyCollection<(GlobalId ModelId, IModelControllerAsync Controller)>(m_controllers);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            for (int i = 0; i < Description.ModelControllerIds.Count; i++)
            {
                (GlobalId modelId, GlobalId controllerId) = Description.ModelControllerIds[i];

                var controller = Application.GetController<IModelControllerAsync>(controllerId);

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
                (GlobalId modelId, IModelControllerAsync controller) = m_controllers[i];

                IModel model = domainModel.Get(modelId);

                await controller.ExecuteAsync(model, context);
            }
        }
    }
}
