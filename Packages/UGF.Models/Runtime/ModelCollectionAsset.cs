using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Models.Runtime
{
    public abstract class ModelCollectionAsset : ScriptableObject
    {
        public void GetModels(IDictionary<Guid, IModel> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));

            OnGetModels(models);
        }

        protected abstract void OnGetModels(IDictionary<Guid, IModel> models);
    }
}
