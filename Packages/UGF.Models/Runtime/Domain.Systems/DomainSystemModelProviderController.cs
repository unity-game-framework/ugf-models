using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public class DomainSystemModelProviderController : DomainSystemModelController<DomainSystemModelProviderControllerDescription>, IDomainSystemModelProviderController
    {
        public IReadOnlyCollection<Guid> ModelIds { get { return m_modelToControllerIds.Keys; } }

        protected IControllerModule ControllerModule { get; }
        protected IControllerInstanceProviderController ProviderController { get; }

        private readonly Dictionary<Guid, Guid> m_modelToControllerIds = new Dictionary<Guid, Guid>();
        private readonly Dictionary<Guid, Guid> m_controllerToModelIds = new Dictionary<Guid, Guid>();
        private readonly HashSet<Guid> m_modelsToRemove = new HashSet<Guid>();

        public DomainSystemModelProviderController(DomainSystemModelProviderControllerDescription description, IApplication application) : base(description, application)
        {
            ControllerModule = Application.GetModule<IControllerModule>();
            ProviderController = Application.GetController<IControllerInstanceProviderController>(Description.ProviderControllerId);
        }

        public bool TryGetControllerId(Guid modelId, out Guid controllerId)
        {
            return m_modelToControllerIds.TryGetValue(modelId, out controllerId);
        }

        public bool TryGetModelId(Guid controllerId, out Guid modelId)
        {
            return m_controllerToModelIds.TryGetValue(controllerId, out modelId);
        }

        protected override void OnExecute(IDomainSystemModel systemModel, IContext context)
        {
            base.OnExecute(systemModel, context);

            UpdateControllers(context);
        }

        protected override void OnExecute(IDomainSystemModel systemModel, IModel model, IContext context)
        {
            var meta = context.Get<IDomainModelMeta>();
            Guid modelId = meta.Ids.Get(model);

            IModelController controller = GetController(modelId, context);

            controller.Execute(model, context);
        }

        protected void UpdateControllers(IContext context)
        {
            var domainModel = context.Get<IDomainModel>();

            foreach ((Guid modelId, _) in m_modelToControllerIds)
            {
                if (!domainModel.Models.ContainsKey(modelId))
                {
                    m_modelsToRemove.Add(modelId);
                }
            }

            foreach (Guid modelId in m_modelsToRemove)
            {
                RemoveController(modelId, context);
            }

            m_modelsToRemove.Clear();
        }

        protected IModelController GetController(Guid modelId, IContext context)
        {
            if (TryGetControllerId(modelId, out Guid controllerId))
            {
                return ControllerModule.Controllers.Get<IModelController>(controllerId);
            }
            else
            {
                controllerId = Guid.NewGuid();

                var controller = ProviderController.Build<IModelController>(Description.ControllerId);

                ControllerModule.Controllers.Add(controllerId, controller);

                m_modelToControllerIds.Add(modelId, controllerId);
                m_controllerToModelIds.Add(controllerId, modelId);

                controller.Initialize();

                return controller;
            }
        }

        protected void RemoveController(Guid modelId, IContext context)
        {
            if (TryGetControllerId(modelId, out Guid controllerId))
            {
                m_modelToControllerIds.Remove(modelId);
                m_controllerToModelIds.Remove(controllerId);

                if (ControllerModule.Controllers.TryGet(controllerId, out IController controller))
                {
                    controller.Uninitialize();

                    ControllerModule.Controllers.Remove(controllerId);
                }
            }
        }
    }
}
