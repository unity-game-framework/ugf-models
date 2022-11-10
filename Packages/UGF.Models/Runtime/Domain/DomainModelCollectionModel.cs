using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelCollectionModel : IModel
    {
        public List<Guid> ModelIds { get; set; } = new List<Guid>();
    }
}
