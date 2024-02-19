using System;

namespace UGF.Models.Runtime
{
    public static class ModelUtility
    {
        public static T CreateCopy<T>(T model) where T : class, IModelCopyable
        {
            return CreateCopy(model, Activator.CreateInstance<T>);
        }

        public static T CreateCopy<T>(T model, ModelCreateHandler<T> createHandler) where T : class, IModelCopyable
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (createHandler == null) throw new ArgumentNullException(nameof(createHandler));

            T copy = createHandler();

            copy.CopyFrom(model);

            return copy;
        }
    }
}
