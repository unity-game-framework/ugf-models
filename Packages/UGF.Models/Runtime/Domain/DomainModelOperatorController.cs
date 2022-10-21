using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelOperatorController : ControllerBase, IDomainModelOperatorController
    {
        public DomainModelOperatorController(IApplication application) : base(application)
        {
        }

        public Guid GenerateId()
        {
            return Guid.NewGuid();
        }

        public Guid Add(IDomainModel domainModel, IModel model, IContext context)
        {
            Guid id = GenerateId();

            Add(domainModel, id, model, context);

            return id;
        }

        public void Add(IDomainModel domainModel, Guid modelId, IModel model, IContext context)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));
            if (context == null) throw new ArgumentNullException(nameof(context));

            var meta = context.Get<IDomainModelMeta>();

            domainModel.Add(modelId, model);
            meta.Ids.Add(model, modelId);
        }

        public bool Remove(IDomainModel domainModel, IModel model, IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var meta = context.Get<IDomainModelMeta>();
            Guid id = meta.Ids.Get(model);

            return Remove(domainModel, id, context);
        }

        public bool Remove(IDomainModel domainModel, Guid modelId, IContext context)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            if (domainModel.TryGet(modelId, out IModel model))
            {
                var meta = context.Get<IDomainModelMeta>();

                domainModel.Remove(modelId);
                meta.Ids.Remove(model);
                return true;
            }

            return false;
        }

        public Guid GetId(IModel model, IContext context)
        {
            return TryGetId(model, context, out Guid id) ? id : throw new ArgumentException($"Id not found by the specified model: '{model}'.");
        }

        public bool TryGetId(IModel model, IContext context, out Guid id)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var meta = context.Get<IDomainModelMeta>();

            return meta.Ids.TryGet(model, out id);
        }
    }
}
