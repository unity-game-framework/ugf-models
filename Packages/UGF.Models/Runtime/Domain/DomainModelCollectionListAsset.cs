﻿using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model Collection List", order = 3000)]
    public class DomainModelCollectionListAsset : DomainModelCollectionAsset
    {
        [SerializeField] private List<AssetIdReference<ModelAsset>> m_models = new List<AssetIdReference<ModelAsset>>();

        public List<AssetIdReference<ModelAsset>> Models { get { return m_models; } }

        protected override void OnGetModels(IDomainModel domainModel)
        {
            for (int i = 0; i < m_models.Count; i++)
            {
                AssetIdReference<ModelAsset> reference = m_models[i];
                IModel model = reference.Asset.Build();

                domainModel.Models.Add(reference.Guid, model);
            }
        }
    }
}