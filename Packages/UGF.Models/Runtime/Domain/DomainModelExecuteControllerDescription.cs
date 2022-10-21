﻿using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelExecuteControllerDescription : ControllerDescription
    {
        public List<(GlobalId ModelId, GlobalId ControllerId)> ModelControllerIds { get; } = new List<(GlobalId ModelId, GlobalId ControllerId)>();
    }
}
