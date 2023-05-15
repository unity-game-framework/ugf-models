using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model", order = 2000)]
    public class DomainModelAsset : ModelAsset
    {
        [SerializeField] private List<AssetIdReference<ModelAsset>> m_models = new List<AssetIdReference<ModelAsset>>();
        [SerializeField] private List<AssetIdReference<DomainModelCollectionAsset>> m_collections = new List<AssetIdReference<DomainModelCollectionAsset>>();
        [SerializeField] private List<ModelCollectionAsset> m_modelCollections = new List<ModelCollectionAsset>();

        public List<AssetIdReference<ModelAsset>> Models { get { return m_models; } }
        public List<AssetIdReference<DomainModelCollectionAsset>> Collections { get { return m_collections; } }
        public List<ModelCollectionAsset> ModelCollections { get { return m_modelCollections; } }

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
                AssetIdReference<DomainModelCollectionAsset> reference = m_collections[i];

                domain.Models.Add(reference.Guid, reference.Asset.Build());

                reference.Asset.GetModels(domain);
            }

            for (int i = 0; i < m_modelCollections.Count; i++)
            {
                ModelCollectionAsset collection = m_modelCollections[i];

                collection.GetModels(domain.Models);
            }

            return domain;
        }
    }
}
