using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelExecuteControllerAsync : ModelControllerAsyncDescribed<DomainModelExecuteControllerDescription, IDomainModel>
    {
        protected IControllerModule ControllerModule { get; }

        public DomainModelExecuteControllerAsync(DomainModelExecuteControllerDescription description, IApplication application) : base(description, application)
        {
            ControllerModule = Application.GetModule<IControllerModule>();
        }

        protected override async Task OnExecuteAsync(IDomainModel domainModel, IContext context)
        {
            for (int i = 0; i < Description.ModelControllerIds.Count; i++)
            {
                (string modelId, string controllerId) = Description.ModelControllerIds[i];

                IModel model = domainModel.Get(modelId);
                var controller = ControllerModule.Provider.Get<IModelControllerAsync>(controllerId);

                await controller.ExecuteAsync(model, context);
            }
        }
    }
}
