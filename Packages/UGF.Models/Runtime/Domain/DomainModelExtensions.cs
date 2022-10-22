using System;

namespace UGF.Models.Runtime.Domain
{
    public static class DomainModelExtensions
    {
        public static T Get<T>(this IDomainModel domainModel, Guid id) where T : IModel
        {
            return (T)Get(domainModel, id);
        }

        public static IModel Get(this IDomainModel domainModel, Guid id)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            return domainModel.TryGet(id, out IModel model) ? model : throw new ArgumentException($"Model not found by the specified id: '{id:N}'.");
        }

        public static bool TryGet<T>(this IDomainModel domainModel, Guid id, out T model) where T : IModel
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            if (domainModel.TryGet(id, out IModel value))
            {
                model = (T)value;
                return true;
            }

            model = default;
            return false;
        }

        public static bool TryGet(this IDomainModel domainModel, Guid id, out IModel model)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            return domainModel.Models.TryGetValue(id, out model);
        }
    }
}
