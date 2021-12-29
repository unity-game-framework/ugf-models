using System.Collections.Generic;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model", order = 2000)]
    public class DomainModelAsset : ModelAsset
    {
        [SerializeField] private List<AssetReference<ModelAsset>> m_models = new List<AssetReference<ModelAsset>>();

        public List<AssetReference<ModelAsset>> Models { get { return m_models; } }

        protected override IModel OnBuild()
        {
            var domain = new DomainModel();

            for (int i = 0; i < m_models.Count; i++)
            {
                AssetReference<ModelAsset> reference = m_models[i];
                IModel model = reference.Asset.Build();

                domain.Add(reference.Guid, model);
            }

            return domain;
        }
    }
}
