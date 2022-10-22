using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain.Systems
{
    public class DomainSystemModel : IDomainSystemModel
    {
        public List<Guid> ModelIds { get; set; } = new List<Guid>();

        IList<Guid> IDomainSystemModel.ModelIds { get { return ModelIds; } }
    }
}
