using System;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    public abstract class DomainModelCollectionAsset : ScriptableObject
    {
        public void GetModels(IDomainModel domainModel)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            OnGetModels(domainModel);
        }

        protected abstract void OnGetModels(IDomainModel domainModel);
    }
}
