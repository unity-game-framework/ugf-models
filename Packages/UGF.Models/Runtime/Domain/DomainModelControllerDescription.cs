using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelControllerDescription : ControllerDescription
    {
        public List<GlobalId> ControllerIds { get; } = new List<GlobalId>();
    }
}
