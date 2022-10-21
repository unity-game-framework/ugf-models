using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Models.Runtime.Domain.Systems
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain System Model Provider Controller", order = 2000)]
    public class DomainSystemModelProviderControllerAsset : ModelControllerDescribedAsset<DomainSystemModelProviderController, DomainSystemModelProviderControllerDescription>
    {
        [AssetId(typeof(ControllerInstanceProviderControllerAsset))]
        [SerializeField] private GlobalId m_provider;
        [AssetId(typeof(ControllerAsset))]
        [SerializeField] private GlobalId m_controller;

        public GlobalId Provider { get { return m_provider; } set { m_provider = value; } }
        public GlobalId Controller { get { return m_controller; } set { m_controller = value; } }

        protected override DomainSystemModelProviderControllerDescription OnBuildDescription()
        {
            var description = new DomainSystemModelProviderControllerDescription
            {
                ProviderControllerId = m_provider,
                ControllerId = m_controller
            };

            return description;
        }

        protected override DomainSystemModelProviderController OnBuild(DomainSystemModelProviderControllerDescription description, IApplication application)
        {
            return new DomainSystemModelProviderController(description, application);
        }
    }
}
