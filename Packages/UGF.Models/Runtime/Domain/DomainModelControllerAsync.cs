using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelControllerAsync : ModelControllerAsyncDescribed<DomainModelControllerDescription, IDomainModel>
    {
        public IDomainModelMeta Meta { get; }

        protected IControllerModule ControllerModule { get; }

        public DomainModelControllerAsync(DomainModelControllerDescription description, IApplication application) : this(description, application, new DomainModelMeta())
        {
        }

        public DomainModelControllerAsync(DomainModelControllerDescription description, IApplication application, IDomainModelMeta meta) : base(description, application)
        {
            Meta = meta ?? throw new ArgumentNullException(nameof(meta));

            ControllerModule = Application.GetModule<IControllerModule>();
        }

        protected override async Task OnExecuteAsync(IDomainModel model, IContext context)
        {
            OnUpdateMeta(model, Meta, context);

            using (new ContextValueScope(context, model))
            using (new ContextValueScope(context, Meta))
            {
                for (int i = 0; i < Description.ControllerIds.Count; i++)
                {
                    string controllerId = Description.ControllerIds[i];
                    var controller = ControllerModule.Provider.Get<IModelControllerAsync>(controllerId);

                    await controller.ExecuteAsync(model, context);
                }
            }
        }

        protected virtual void OnUpdateMeta(IDomainModel domainModel, IDomainModelMeta meta, IContext context)
        {
            meta.Ids.Clear();

            if (domainModel is DomainModel regular)
            {
                foreach ((string key, IModel value) in regular.Models)
                {
                    meta.Ids.Add(key, value);
                }
            }
            else
            {
                foreach ((string id, IModel model) in domainModel.Models)
                {
                    meta.Ids.Add(id, model);
                }
            }
        }
    }
}
