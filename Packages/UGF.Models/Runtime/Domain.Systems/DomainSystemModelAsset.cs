using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Models.Runtime.Domain.Systems
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain System Model", order = 2000)]
    public class DomainSystemModelAsset : ModelAsset
    {
        [AssetId(typeof(ModelAsset))]
        [SerializeField] private List<GlobalId> m_models = new List<GlobalId>();

        public List<GlobalId> Models { get { return m_models; } }

        protected override IModel OnBuild()
        {
            var model = new DomainSystemModel();

            for (int i = 0; i < m_models.Count; i++)
            {
                model.ModelIds.Add(m_models[i]);
            }

            return model;
        }
    }
}
