using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model", order = 2000)]
    public class DomainModelAsset : ModelAsset
    {
        [SerializeField] private List<AssetIdReference<ModelAsset>> m_models = new List<AssetIdReference<ModelAsset>>();
        [SerializeField] private List<ModelCollectionAsset> m_collections = new List<ModelCollectionAsset>();

        public List<AssetIdReference<ModelAsset>> Models { get { return m_models; } }
        public List<ModelCollectionAsset> Collections { get { return m_collections; } }

        protected override IModel OnBuild()
        {
            var domain = new DomainModel();

            for (int i = 0; i < m_models.Count; i++)
            {
                AssetIdReference<ModelAsset> reference = m_models[i];

                domain.Models.Add(reference.Guid, reference.Asset.Build());
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                ModelCollectionAsset collection = m_collections[i];

                collection.GetModels(domain.Models);
            }

            return domain;
        }
    }
}
