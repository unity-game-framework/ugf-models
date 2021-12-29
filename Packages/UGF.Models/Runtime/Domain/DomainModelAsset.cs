using System.Collections.Generic;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
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
