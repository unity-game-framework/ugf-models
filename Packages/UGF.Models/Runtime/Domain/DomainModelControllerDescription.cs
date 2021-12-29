using System.Collections.Generic;
using UGF.Module.Controllers.Runtime;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelControllerDescription : ControllerDescription
    {
        public List<string> ControllerIds { get; } = new List<string>();
    }
}
