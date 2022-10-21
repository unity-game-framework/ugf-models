using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public static class DomainSystemModelProviderControllerExtensions
    {
        public static T GetController<T>(this IDomainSystemModelProviderController provider, Guid modelId, IApplication application) where T : class, IController
        {
            return (T)GetController(provider, modelId, application);
        }

        public static IController GetController(this IDomainSystemModelProviderController provider, Guid modelId, IApplication application)
        {
            return TryGetController(provider, modelId, application, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified model id: '{modelId}'.");
        }

        public static bool TryGetController<T>(this IDomainSystemModelProviderController provider, Guid modelId, IApplication application, out T controller) where T : IController
        {
            if (TryGetController(provider, modelId, application, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public static bool TryGetController(this IDomainSystemModelProviderController provider, Guid modelId, IApplication application, out IController controller)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (application == null) throw new ArgumentNullException(nameof(application));

            controller = default;
            return provider.TryGetControllerId(modelId, out Guid controllerId) && application.TryGetController(controllerId, out controller);
        }

        public static T GetModel<T>(this IDomainSystemModelProviderController provider, Guid controllerId, IContext context) where T : class, IModel
        {
            return (T)GetModel(provider, controllerId, context);
        }

        public static IModel GetModel(this IDomainSystemModelProviderController provider, Guid controllerId, IContext context)
        {
            return TryGetModel(provider, controllerId, context, out IModel model) ? model : throw new ArgumentException($"Model not found by the specified controller id: '{controllerId}'.");
        }

        public static bool TryGetModel<T>(this IDomainSystemModelProviderController provider, Guid controllerId, IContext context, out T model) where T : class, IModel
        {
            if (TryGetModel(provider, controllerId, context, out IModel value))
            {
                model = (T)value;
                return true;
            }

            model = default;
            return false;
        }

        public static bool TryGetModel(this IDomainSystemModelProviderController provider, Guid controllerId, IContext context, out IModel model)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (context == null) throw new ArgumentNullException(nameof(context));

            model = default;
            return provider.TryGetModelId(controllerId, out Guid modelId) && context.Get<IDomainModel>().TryGet(modelId, out model);
        }

        public static Guid GetControllerId(this IDomainSystemModelProviderController provider, Guid modelId)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            return provider.TryGetControllerId(modelId, out Guid id) ? id : throw new ArgumentException($"Controller id not found by the specified model id: '{modelId}'.");
        }

        public static Guid GetModelId(this IDomainSystemModelProviderController provider, Guid controllerId)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            return provider.TryGetModelId(controllerId, out Guid id) ? id : throw new ArgumentException($"Model id not found by the specified controller id: '{controllerId}'.");
        }
    }
}
