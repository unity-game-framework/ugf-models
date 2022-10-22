using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain.Systems
{
    public interface IDomainSystemModel : IModel
    {
        public IList<Guid> ModelIds { get; }
    }
}
