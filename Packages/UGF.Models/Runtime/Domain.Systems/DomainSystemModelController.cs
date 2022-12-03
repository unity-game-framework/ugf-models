using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public abstract class DomainSystemModelController<TDescription> : ModelControllerDescribed<TDescription, IDomainSystemModel> where TDescription : class, IControllerDescription
    {
        public event DomainSystemModelChangeHandler Added;
        public event DomainSystemModelChangeHandler Removed;
        public event DomainSystemModelChangeHandler Changed;
        public event DomainSystemModelClearHandler Cleared;
        public event DomainSystemModelChangeHandler Executed;

        protected DomainSystemModelController(TDescription description, IApplication application) : base(description, application)
        {
        }

        public void Add(IDomainSystemModel systemModel, Guid id, IContext context)
        {
            if (systemModel == null) throw new ArgumentNullException(nameof(systemModel));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (context == null) throw new ArgumentNullException(nameof(context));

            systemModel.ModelIds.Add(id);

            Added?.Invoke(systemModel, systemModel.ModelIds.Count - 1, id, context);
        }

        public void Add(IDomainSystemModel systemModel, int index, Guid id, IContext context)
        {
            if (systemModel == null) throw new ArgumentNullException(nameof(systemModel));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (context == null) throw new ArgumentNullException(nameof(context));

            systemModel.ModelIds.Insert(index, id);

            Added?.Invoke(systemModel, index, id, context);
        }

        public void Remove(IDomainSystemModel systemModel, int index, IContext context)
        {
            if (systemModel == null) throw new ArgumentNullException(nameof(systemModel));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (context == null) throw new ArgumentNullException(nameof(context));

            Guid id = systemModel.ModelIds[index];

            systemModel.ModelIds.RemoveAt(index);

            Removed?.Invoke(systemModel, index, id, context);
        }

        public bool Remove(IDomainSystemModel systemModel, Guid id, IContext context)
        {
            if (systemModel == null) throw new ArgumentNullException(nameof(systemModel));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (context == null) throw new ArgumentNullException(nameof(context));

            int index = systemModel.ModelIds.IndexOf(id);

            if (index >= 0)
            {
                systemModel.ModelIds.RemoveAt(index);

                Removed?.Invoke(systemModel, index, id, context);
                return true;
            }

            return false;
        }

        public void Change(IDomainSystemModel systemModel, int index, Guid id, IContext context)
        {
            if (systemModel == null) throw new ArgumentNullException(nameof(systemModel));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (context == null) throw new ArgumentNullException(nameof(context));

            systemModel.ModelIds[index] = id;

            Changed?.Invoke(systemModel, index, id, context);
        }

        public void Clear(IDomainSystemModel systemModel, IContext context)
        {
            if (systemModel == null) throw new ArgumentNullException(nameof(systemModel));
            if (context == null) throw new ArgumentNullException(nameof(context));

            systemModel.ModelIds.Clear();

            Cleared?.Invoke(systemModel, context);
        }

        protected override void OnExecute(IDomainSystemModel systemModel, IContext context)
        {
            var domainModel = context.Get<IDomainModel>();

            for (int i = 0; i < systemModel.ModelIds.Count; i++)
            {
                Guid id = systemModel.ModelIds[i];
                IModel model = domainModel.Get(id);

                OnExecute(systemModel, id, model, context);

                Executed?.Invoke(systemModel, i, id, context);
            }
        }

        protected abstract void OnExecute(IDomainSystemModel systemModel, Guid id, IModel model, IContext context);
    }
}
