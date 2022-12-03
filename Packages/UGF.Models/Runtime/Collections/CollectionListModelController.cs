using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionListModelController<TModel> : ModelController<CollectionListModel<TModel>> where TModel : class, IModel
    {
        public event CollectionListModelChangeHandler<TModel> Added;
        public event CollectionListModelChangeHandler<TModel> Removed;
        public event CollectionListModelChangeHandler<TModel> Executed;

        public CollectionListModelController(IApplication application) : base(application)
        {
        }

        public void Add(CollectionListModel<TModel> collection, TModel model)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (model == null) throw new ArgumentNullException(nameof(model));

            collection.Models.Add(model);

            Added?.Invoke(collection, collection.Models.Count - 1, model);
        }

        public void Add(CollectionListModel<TModel> collection, int index, TModel model)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (model == null) throw new ArgumentNullException(nameof(model));

            collection.Models.Insert(index, model);

            Added?.Invoke(collection, index, model);
        }

        public void Remove(CollectionListModel<TModel> collection, int index)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            TModel model = collection.Models[index];

            collection.Models.RemoveAt(index);

            Removed?.Invoke(collection, index, model);
        }

        public bool Remove(CollectionListModel<TModel> collection, TModel model)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (model == null) throw new ArgumentNullException(nameof(model));

            int index = collection.Models.IndexOf(model);

            if (index >= 0)
            {
                collection.Models.RemoveAt(index);

                Removed?.Invoke(collection, index, model);
                return true;
            }

            return false;
        }

        protected override void OnExecute(CollectionListModel<TModel> collection, IContext context)
        {
            for (int i = 0; i < collection.Models.Count; i++)
            {
                TModel model = collection.Models[i];

                OnExecute(collection, i, model, context);

                Executed?.Invoke(collection, i, model);
            }
        }

        protected virtual void OnExecute(CollectionListModel<TModel> collection, int index, TModel model, IContext context)
        {
        }
    }
}
