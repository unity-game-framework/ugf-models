using System.Collections.Generic;
using UnityEngine;

namespace UGF.Models.Runtime.Collections
{
    public abstract class CollectionListModelAsset<TModel, TModelAsset> : ModelAsset
        where TModel : IModel
        where TModelAsset : ModelAsset
    {
        [SerializeField] private List<TModelAsset> m_models = new List<TModelAsset>();

        public List<TModelAsset> Models { get { return m_models; } }

        protected override IModel OnBuild()
        {
            var model = new CollectionListModel<TModel>();

            for (int i = 0; i < m_models.Count; i++)
            {
                TModelAsset asset = m_models[i];

                model.Models.Add(asset.Build<TModel>());
            }

            return model;
        }
    }
}
