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

        public void Add(DomainModelGroupModel groupModel, Guid key, Guid value, IContext context)
        {
            if (groupModel == null) throw new ArgumentNullException(nameof(groupModel));
            if (key == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(key));
            if (context == null) throw new ArgumentNullException(nameof(context));

            groupModel.ModelIds.Add(key, value);

            Added?.Invoke(groupModel, key, value, context);
        }

        public bool Remove(DomainModelGroupModel groupModel, Guid key, IContext context)
        {
            return Remove(groupModel, key, context, out _);
        }

        public bool Remove(DomainModelGroupModel groupModel, Guid key, IContext context, out Guid value)
        {
            if (groupModel == null) throw new ArgumentNullException(nameof(groupModel));
            if (key == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(key));
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (groupModel.ModelIds.Remove(key, out value))
            {
                Removed?.Invoke(groupModel, key, value, context);
                return true;
            }

            value = default;
            return false;
        }

        public void Change(DomainModelGroupModel groupModel, Guid key, Guid value, IContext context)
        {
            if (groupModel == null) throw new ArgumentNullException(nameof(groupModel));
            if (key == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(key));
            if (value == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(value));
            if (context == null) throw new ArgumentNullException(nameof(context));

            groupModel.ModelIds[key] = value;

            Changed?.Invoke(groupModel, key, value, context);
        }

        public void Clear(DomainModelGroupModel groupModel, IContext context)
        {
            if (groupModel == null) throw new ArgumentNullException(nameof(groupModel));
            if (context == null) throw new ArgumentNullException(nameof(context));

            groupModel.ModelIds.Clear();

            Cleared?.Invoke(groupModel, context);
        }

        protected override void OnExecute(DomainModelGroupModel groupModel, IContext context)
        {
            foreach ((Guid key, Guid value) in groupModel.ModelIds)
            {
                OnExecute(groupModel, key, value, context);

                Executed?.Invoke(groupModel, key, value, context);
            }
        }

        protected virtual void OnExecute(DomainModelGroupModel groupModel, Guid key, Guid value, IContext context)
        {
        }
    }
}
