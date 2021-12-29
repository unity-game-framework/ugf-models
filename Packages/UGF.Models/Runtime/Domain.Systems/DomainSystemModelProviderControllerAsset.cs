using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Models.Runtime.Domain.Systems
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain System Model Provider Controller", order = 2000)]
    public class DomainSystemModelProviderControllerAsset : ModelControllerDescribedAsset<DomainSystemModelProviderController, DomainSystemModelProviderControllerDescription>
    {
        [AssetGuid(typeof(ControllerInstanceProviderControllerAsset))]
        [SerializeField] private string m_provider;
        [AssetGuid(typeof(ControllerAsset))]
        [SerializeField] private string m_controller;

        public string Provider { get { return m_provider; } set { m_provider = value; } }
        public string Controller { get { return m_controller; } set { m_controller = value; } }

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
