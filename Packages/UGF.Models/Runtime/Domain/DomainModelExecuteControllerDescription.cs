using System.Collections.Generic;
using UGF.Module.Controllers.Runtime;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelExecuteControllerDescription : ControllerDescription
    {
        public List<(string ModelId, string ControllerId)> ModelControllerIds { get; } = new List<(string ModelId, string ControllerId)>();
    }
}
