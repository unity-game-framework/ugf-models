using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Models.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Model Collection List", order = 2000)]
    public class ModelCollectionListAsset : ModelCollectionAsset
    {
        [SerializeField] private List<AssetIdReference<ModelAsset>> m_models = new List<AssetIdReference<ModelAsset>>();

        public List<AssetIdReference<ModelAsset>> Models { get { return m_models; } }

        protected override void OnGetModels(IDictionary<Guid, IModel> models)
        {
            for (int i = 0; i < m_models.Count; i++)
            {
                AssetIdReference<ModelAsset> reference = m_models[i];

                models.Add(reference.Guid, reference.Asset.Build());
            }
        }
    }
}
