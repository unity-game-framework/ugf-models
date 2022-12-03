using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelControllerAsync : ModelControllerAsyncDescribed<DomainModelControllerDescription, IDomainModel>
    {
        public IReadOnlyList<(GlobalId ModelId, IModelControllerAsync Controller)> Controllers { get; }

        public event DomainModelChangeHandler Added;
        public event DomainModelChangeHandler Removed;
        public event DomainModelChangeHandler Changed;
        public event DomainModelClearHandler Cleared;
        public event DomainModelChangeHandler Executed;

        private readonly List<(GlobalId ModelId, IModelControllerAsync Controller)> m_controllers = new List<(GlobalId ModelId, IModelControllerAsync Controller)>();

        public DomainModelControllerAsync(DomainModelControllerDescription description, IApplication application) : base(description, application)
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

        public void Add(IDomainModel domainModel, Guid id, IModel model, IContext context)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            domainModel.Models.Add(id, model);

            Added?.Invoke(domainModel, id, model, context);
        }

        public bool Remove(IDomainModel domainModel, Guid id, IContext context)
        {
            return Remove(domainModel, id, context, out _);
        }

        public bool Remove(IDomainModel domainModel, Guid id, IContext context, out IModel model)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (domainModel.Models.Remove(id, out model))
            {
                Removed?.Invoke(domainModel, id, model, context);
                return true;
            }

            model = default;
            return false;
        }

        public void Change(IDomainModel domainModel, Guid id, IModel model, IContext context)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            domainModel.Models[id] = model;

            Changed?.Invoke(domainModel, id, model, context);
        }

        public void Clear(IDomainModel domainModel, IContext context)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));
            if (context == null) throw new ArgumentNullException(nameof(context));

            domainModel.Models.Clear();

            Cleared?.Invoke(domainModel, context);
        }

        protected override async Task OnExecuteAsync(IDomainModel domainModel, IContext context)
        {
            using (new ContextValueScope(context, domainModel))
            {
                for (int i = 0; i < m_controllers.Count; i++)
                {
                    (GlobalId modelId, IModelControllerAsync controller) = m_controllers[i];

                    IModel model = domainModel.Get(modelId);

                    await controller.ExecuteAsync(model, context);

                    Executed?.Invoke(domainModel, modelId, model, context);
                }
            }
        }
    }
}
