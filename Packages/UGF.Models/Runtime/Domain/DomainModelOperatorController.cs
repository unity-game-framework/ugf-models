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

        public string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }

        public string Add(IDomainModel domainModel, IModel model, IContext context)
        {
            string id = GenerateId();

            Add(domainModel, id, model, context);

            return id;
        }

        public void Add(IDomainModel domainModel, string modelId, IModel model, IContext context)
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
            string id = meta.Ids.Get(model);

            return Remove(domainModel, id, context);
        }

        public bool Remove(IDomainModel domainModel, string modelId, IContext context)
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

        public string GetId(IModel model, IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var meta = context.Get<IDomainModelMeta>();
            string id = meta.Ids.Get(model);

            return id;
        }
    }
}
