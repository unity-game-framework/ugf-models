using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model Controller Async", order = 2000)]
    public class DomainModelControllerAsyncAsset : ModelControllerDescribedAsset<DomainModelControllerAsync, DomainModelControllerDescription>
    {
        [AssetId(typeof(ModelControllerAsset))]
        [SerializeField] private List<GlobalId> m_controllers = new List<GlobalId>();

        public List<GlobalId> Controllers { get { return m_controllers; } }

        protected override DomainModelControllerDescription OnBuildDescription()
        {
            var description = new DomainModelControllerDescription();

            for (int i = 0; i < m_controllers.Count; i++)
            {
                description.ControllerIds.Add(m_controllers[i]);
            }

            return description;
        }

        protected override DomainModelControllerAsync OnBuild(DomainModelControllerDescription description, IApplication application)
        {
            return new DomainModelControllerAsync(description, application);
        }
    }
}
