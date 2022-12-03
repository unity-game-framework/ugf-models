using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Models.Runtime.Collections
{
    public abstract class CollectionDictionaryModelAsset<TModel, TModelAsset> : ModelAsset
        where TModel : class, IModel
        where TModelAsset : ModelAsset
    {
        [SerializeField] private List<AssetIdReference<TModelAsset>> m_models = new List<AssetIdReference<TModelAsset>>();

        public List<AssetIdReference<TModelAsset>> Models { get { return m_models; } }

        protected override IModel OnBuild()
        {
            var model = new CollectionDictionaryModel<TModel>();

            for (int i = 0; i < m_models.Count; i++)
            {
                AssetIdReference<TModelAsset> reference = m_models[i];

                model.Models.Add(reference.Guid, reference.Asset.Build<TModel>());
            }

            return model;
        }
    }
}
