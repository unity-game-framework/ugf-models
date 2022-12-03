using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelGroupModelController : ModelController<DomainModelGroupModel>
    {
        public event DomainModelGroupModelChangeHandler Added;
        public event DomainModelGroupModelChangeHandler Removed;
        public event DomainModelGroupModelChangeHandler Changed;
        public event DomainModelGroupModelClearHandler Cleared;
        public event DomainModelGroupModelChangeHandler Executed;

        public DomainModelGroupModelController(IApplication application) : base(application)
        {
        }

        public void Add(DomainModelGroupModel group, Guid key, Guid value, IContext context)
        {
            if (group == null) throw new ArgumentNullException(nameof(group));
            if (key == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(key));
            if (context == null) throw new ArgumentNullException(nameof(context));

            group.ModelIds.Add(key, value);

            Added?.Invoke(group, key, value, context);
        }

        public bool Remove(DomainModelGroupModel group, Guid key, IContext context)
        {
            return Remove(group, key, context, out _);
        }

        public bool Remove(DomainModelGroupModel group, Guid key, IContext context, out Guid value)
        {
            if (group == null) throw new ArgumentNullException(nameof(group));
            if (key == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(key));
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (group.ModelIds.Remove(key, out value))
            {
                Removed?.Invoke(group, key, value, context);
                return true;
            }

            value = default;
            return false;
        }

        public void Change(DomainModelGroupModel group, Guid key, Guid value, IContext context)
        {
            if (group == null) throw new ArgumentNullException(nameof(group));
            if (key == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(key));
            if (value == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(value));
            if (context == null) throw new ArgumentNullException(nameof(context));

            group.ModelIds[key] = value;

            Changed?.Invoke(group, key, value, context);
        }

        public void Clear(DomainModelGroupModel group, IContext context)
        {
            if (group == null) throw new ArgumentNullException(nameof(group));
            if (context == null) throw new ArgumentNullException(nameof(context));

            group.ModelIds.Clear();

            Cleared?.Invoke(group, context);
        }

        protected override void OnExecute(DomainModelGroupModel group, IContext context)
        {
            foreach ((Guid key, Guid value) in group.ModelIds)
            {
                OnExecute(group, key, value, context);

                Executed?.Invoke(group, key, value, context);
            }
        }

        protected virtual void OnExecute(DomainModelGroupModel group, Guid key, Guid value, IContext context)
        {
        }
    }
}
