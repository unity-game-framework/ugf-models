using UGF.Module.Controllers.Runtime;

namespace UGF.Models.Runtime.Domain.Systems
{
    public class DomainSystemModelProviderControllerDescription : ControllerDescription
    {
        public string ProviderControllerId { get; set; }
        public string ControllerId { get; set; }
    }
}
