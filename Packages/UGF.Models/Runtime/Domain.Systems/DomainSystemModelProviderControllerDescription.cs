using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;

namespace UGF.Models.Runtime.Domain.Systems
{
    public class DomainSystemModelProviderControllerDescription : ControllerDescription
    {
        public GlobalId ProviderControllerId { get; set; }
        public GlobalId ControllerId { get; set; }
    }
}
