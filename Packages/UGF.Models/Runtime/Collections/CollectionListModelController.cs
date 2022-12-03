using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionListModelController<TModel> : ModelController<CollectionListModel<TModel>> where TModel : class, IModel
    {
        public event CollectionListModelChangeHandler<TModel> Added;
        public event CollectionListModelChangeHandler<TModel> Removed;
        public event CollectionListModelChangeHandler<TModel> Changed;
        public event CollectionListModelHandler<TModel> Cleared;
        public event CollectionListModelChangeHandler<TModel> Executed;

        public CollectionListModelController(IApplication application) : base(application)
        {
        }

        public void Add(CollectionListModel<TModel> collection, TModel model, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            collection.Models.Add(model);

            Added?.Invoke(collection, collection.Models.Count - 1, model, context);
        }

        public void Add(CollectionListModel<TModel> collection, int index, TModel model, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            collection.Models.Insert(index, model);

            Added?.Invoke(collection, index, model, context);
        }

        public void Remove(CollectionListModel<TModel> collection, int index, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            TModel model = collection.Models[index];

            collection.Models.RemoveAt(index);

            Removed?.Invoke(collection, index, model, context);
        }

        public bool Remove(CollectionListModel<TModel> collection, TModel model, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (model == null) throw new ArgumentNullException(nameof(model));

            int index = collection.Models.IndexOf(model);

            if (index >= 0)
            {
                collection.Models.RemoveAt(index);

                Removed?.Invoke(collection, index, model, context);
                return true;
            }

            return false;
        }

        public void Change(CollectionListModel<TModel> collection, int index, TModel model, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (context == null) throw new ArgumentNullException(nameof(context));

            collection.Models[index] = model;

            Changed?.Invoke(collection, index, model, context);
        }

        public void Clear(CollectionListModel<TModel> collection, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            collection.Models.Clear();

            Cleared?.Invoke(collection, context);
        }

        protected override void OnExecute(CollectionListModel<TModel> collection, IContext context)
        {
            for (int i = 0; i < collection.Models.Count; i++)
            {
                TModel model = collection.Models[i];

                OnExecute(collection, i, model, context);

                Executed?.Invoke(collection, i, model, context);
            }
        }

        protected virtual void OnExecute(CollectionListModel<TModel> collection, int index, TModel model, IContext context)
        {
        }
    }
}
