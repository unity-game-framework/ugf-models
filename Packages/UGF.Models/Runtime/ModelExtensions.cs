using System;

namespace UGF.Models.Runtime
{
    public static class ModelExtensions
    {
        public static T Clone<T>(this IModelCloneable model) where T : IModel
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return (T)model.Clone();
        }
    }
}
