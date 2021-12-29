using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model Operator Controller", order = 2000)]
    public class DomainModelOperatorControllerAsset : ControllerAsset
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new DomainModelOperatorController(arguments);
        }
    }
}
