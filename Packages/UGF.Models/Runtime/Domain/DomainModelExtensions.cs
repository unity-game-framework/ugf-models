﻿using System;

namespace UGF.Models.Runtime.Domain
{
    public static class DomainModelExtensions
    {
        public static T Get<T>(this IDomainModel domainModel, string id) where T : IModel
        {
            return (T)Get(domainModel, id);
        }

        public static IModel Get(this IDomainModel domainModel, string id)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            return domainModel.TryGet(id, out IModel model) ? model : throw new ArgumentException($"Model not found by the specified id: '{id}'.");
        }

        public static bool TryGet<T>(this IDomainModel domainModel, string id, out T model) where T : IModel
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
    }
}