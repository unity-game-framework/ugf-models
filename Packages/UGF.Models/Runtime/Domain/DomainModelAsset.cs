using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model", order = 2000)]
    public class DomainModelAsset : ModelAsset
    {
        [SerializeField] private List<AssetIdReference<ModelAsset>> m_models = new List<AssetIdReference<ModelAsset>>();

        public List<AssetIdReference<ModelAsset>> Models { get { return m_models; } }

        protected override IModel OnBuild()
        {
            var domain = new DomainModel();

            for (int i = 0; i < m_models.Count; i++)
            {
                AssetIdReference<ModelAsset> reference = m_models[i];
                IModel model = reference.Asset.Build();

                domain.Models.Add(reference.Guid, model);
            }

            return domain;
        }
    }
}
