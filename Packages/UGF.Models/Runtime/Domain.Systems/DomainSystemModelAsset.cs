using UnityEngine;

namespace UGF.Models.Runtime.Domain.Systems
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain System Model", order = 2000)]
    public class DomainSystemModelAsset : ModelAsset
    {
        protected override IModel OnBuild()
        {
            return new DomainSystemModel();
        }
    }
}
