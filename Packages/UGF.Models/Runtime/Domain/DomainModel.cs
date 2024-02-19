using System;
using System.Collections.Generic;
using UGF.Models.Runtime.Collections;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModel : CollectionDictionaryModel<IModel>, IDomainModel
    {
        IDictionary<Guid, IModel> IDomainModel.Models { get { return Models; } }

        protected override void OnClear()
        {
            foreach ((_, IModel model) in Models)
            {
                if (model is IModelClearable clearable)
                {
                    clearable.Clear();
                }
            }
        }

        protected override void OnCopyFrom(CollectionDictionaryModel<IModel> collection)
        {
            foreach ((Guid id, IModel modelTo) in Models)
            {
                if (modelTo is IModelCopyable copyableTo && collection.Models.TryGetValue(id, out IModel modelFrom))
                {
                    copyableTo.CopyFrom(modelFrom);
                }
            }
        }

        protected override IModel OnClone()
        {
            var domainModel = new DomainModel();

            foreach ((Guid id, IModel model) in Models)
            {
                if (model is IModelCloneable cloneable)
                {
                    IModel clone = cloneable.Clone();

                    domainModel.Models.Add(id, clone);
                }
            }

            return domainModel;
        }
    }
}
