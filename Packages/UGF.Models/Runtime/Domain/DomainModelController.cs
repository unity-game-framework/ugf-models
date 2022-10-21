using System;
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
        public IDomainModelMeta Meta { get; }
        public IReadOnlyList<IModelController> Controllers { get; }

        private readonly List<IModelController> m_controllers = new List<IModelController>();

        public DomainModelController(DomainModelControllerDescription description, IApplication application) : this(description, application, new DomainModelMeta())
        {
        }

        public DomainModelController(DomainModelControllerDescription description, IApplication application, IDomainModelMeta meta) : base(description, application)
        {
            Meta = meta ?? throw new ArgumentNullException(nameof(meta));
            Controllers = new ReadOnlyCollection<IModelController>(m_controllers);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            for (int i = 0; i < Description.ControllerIds.Count; i++)
            {
                GlobalId id = Description.ControllerIds[i];
                var controller = Application.GetController<IModelController>(id);

                m_controllers.Add(controller);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_controllers.Clear();
        }

        protected override void OnExecute(IDomainModel model, IContext context)
        {
            OnUpdateMeta(model, Meta, context);

            using (new ContextValueScope(context, model))
            using (new ContextValueScope(context, Meta))
            {
                for (int i = 0; i < m_controllers.Count; i++)
                {
                    IModelController controller = m_controllers[i];

                    controller.Execute(model, context);
                }
            }
        }

        protected virtual void OnUpdateMeta(IDomainModel domainModel, IDomainModelMeta meta, IContext context)
        {
            meta.Ids.Clear();

            if (domainModel is DomainModel regular)
            {
                foreach ((Guid key, IModel value) in regular.Models)
                {
                    meta.Ids.Add(value, key);
                }
            }
            else
            {
                foreach ((Guid id, IModel model) in domainModel.Models)
                {
                    meta.Ids.Add(model, id);
                }
            }
        }
    }
}
