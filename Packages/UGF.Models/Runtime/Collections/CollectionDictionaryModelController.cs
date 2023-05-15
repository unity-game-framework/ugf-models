using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionDictionaryModelController<TModel> : ModelController<CollectionDictionaryModel<TModel>> where TModel : IModel
    {
        public event CollectionDictionaryModelChangeHandler<TModel> Added;
        public event CollectionDictionaryModelChangeHandler<TModel> Removed;
        public event CollectionDictionaryModelChangeHandler<TModel> Changed;
        public event CollectionDictionaryModelClearHandler<TModel> Cleared;
        public event CollectionDictionaryModelChangeHandler<TModel> Executed;

        public CollectionDictionaryModelController(IApplication application) : base(application)
        {
        }

        public void Add(CollectionDictionaryModel<TModel> collection, Guid id, TModel model, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            collection.Models.Add(id, model);

            Added?.Invoke(collection, id, model, context);
        }

        public bool Remove(CollectionDictionaryModel<TModel> collection, Guid id, IContext context)
        {
            return Remove(collection, id, context, out _);
        }

        public bool Remove(CollectionDictionaryModel<TModel> collection, Guid id, IContext context, out TModel model)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (collection.Models.Remove(id, out model))
            {
                Removed?.Invoke(collection, id, model, context);
                return true;
            }

            model = default;
            return false;
        }

        public void Change(CollectionDictionaryModel<TModel> collection, Guid id, TModel model, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (id == Guid.Empty) throw new ArgumentException("Value should be valid.", nameof(id));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            collection.Models[id] = model;

            Changed?.Invoke(collection, id, model, context);
        }

        public void Clear(CollectionDictionaryModel<TModel> collection, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            collection.Models.Clear();

            Cleared?.Invoke(collection, context);
        }

        protected override void OnExecute(CollectionDictionaryModel<TModel> collection, IContext context)
        {
            foreach ((Guid id, TModel model) in collection.Models)
            {
                OnExecute(collection, id, model, context);

                Executed?.Invoke(collection, id, model, context);
            }
        }

        protected virtual void OnExecute(CollectionDictionaryModel<TModel> collection, Guid id, TModel model, IContext context)
        {
        }
    }
}
