using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Models.Runtime.Domain.Systems
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain System Model Operator Controller", order = 2000)]
    public class DomainSystemModelOperatorControllerAsset : ControllerDescribedAsset<DomainSystemModelOperatorController, DomainSystemModelOperatorControllerDescription>
    {
        [AssetGuid(typeof(DomainModelOperatorControllerAsset))]
        [SerializeField] private string m_domainModelOperatorController;

        public string DomainModelOperatorController { get { return m_domainModelOperatorController; } set { m_domainModelOperatorController = value; } }

        protected override DomainSystemModelOperatorControllerDescription OnBuildDescription()
        {
            var description = new DomainSystemModelOperatorControllerDescription
            {
                DomainModelOperatorControllerId = m_domainModelOperatorController
            };

            return description;
        }

        protected override DomainSystemModelOperatorController OnBuild(DomainSystemModelOperatorControllerDescription description, IApplication application)
        {
            return new DomainSystemModelOperatorController(description, application);
        }
    }
}
