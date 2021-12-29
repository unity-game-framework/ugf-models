using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public class DomainSystemModelProviderController : DomainSystemModelController<DomainSystemModelProviderControllerDescription>, IDomainSystemModelProviderController
    {
        public IReadOnlyCollection<string> ModelIds { get { return m_modelToControllerIds.Keys; } }

        protected IControllerModule ControllerModule { get; }
        protected IControllerInstanceProviderController ProviderController { get; }

        private readonly Dictionary<string, string> m_modelToControllerIds = new Dictionary<string, string>();
        private readonly Dictionary<string, string> m_controllerToModelIds = new Dictionary<string, string>();
        private readonly HashSet<string> m_modelsToRemove = new HashSet<string>();

        public DomainSystemModelProviderController(DomainSystemModelProviderControllerDescription description, IApplication application) : base(description, application)
        {
            ControllerModule = Application.GetModule<IControllerModule>();
            ProviderController = Application.GetController<IControllerInstanceProviderController>(Description.ProviderControllerId);
        }

        public bool TryGetControllerId(string modelId, out string controllerId)
        {
            if (string.IsNullOrEmpty(modelId)) throw new ArgumentException("Value cannot be null or empty.", nameof(modelId));

            return m_modelToControllerIds.TryGetValue(modelId, out controllerId);
        }

        public bool TryGetModelId(string controllerId, out string modelId)
        {
            if (string.IsNullOrEmpty(controllerId)) throw new ArgumentException("Value cannot be null or empty.", nameof(controllerId));

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
            string modelId = meta.Ids.Get(model);

            IModelController controller = GetController(modelId, context);

            controller.Execute(model, context);
        }

        protected void UpdateControllers(IContext context)
        {
            var domainModel = context.Get<IDomainModel>();

            foreach ((string modelId, _) in m_modelToControllerIds)
            {
                if (!domainModel.Models.ContainsKey(modelId))
                {
                    m_modelsToRemove.Add(modelId);
                }
            }

            foreach (string modelId in m_modelsToRemove)
            {
                RemoveController(modelId, context);
            }

            m_modelsToRemove.Clear();
        }

        protected IModelController GetController(string modelId, IContext context)
        {
            if (TryGetControllerId(modelId, out string controllerId))
            {
                return ControllerModule.Provider.Get<IModelController>(controllerId);
            }
            else
            {
                controllerId = Guid.NewGuid().ToString("N");

                var controller = ProviderController.Build<IModelController>(Description.ControllerId);

                ControllerModule.Provider.Add(controllerId, controller);

                m_modelToControllerIds.Add(modelId, controllerId);
                m_controllerToModelIds.Add(controllerId, modelId);

                controller.Initialize();

                return controller;
            }
        }

        protected void RemoveController(string modelId, IContext context)
        {
            if (TryGetControllerId(modelId, out string controllerId))
            {
                m_modelToControllerIds.Remove(modelId);
                m_controllerToModelIds.Remove(controllerId);

                if (ControllerModule.Provider.TryGet(controllerId, out IController controller))
                {
                    controller.Uninitialize();

                    ControllerModule.Provider.Remove(controllerId);
                }
            }
        }
    }
}
