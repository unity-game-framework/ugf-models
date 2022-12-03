using System;

namespace UGF.Models.Runtime.Domain
{
    public abstract class DomainModelCollectionAsset : ModelAsset
    {
        public void GetModels(IDomainModel domainModel)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            OnGetModels(domainModel);
        }

        protected abstract void OnGetModels(IDomainModel domainModel);
    }
}
