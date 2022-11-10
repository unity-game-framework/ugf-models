using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelGroupModel : IModel
    {
        public Dictionary<Guid, Guid> ModelIds { get; set; } = new Dictionary<Guid, Guid>();
    }
}
