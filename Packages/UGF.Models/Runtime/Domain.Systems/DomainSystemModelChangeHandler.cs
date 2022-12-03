using System;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public delegate void DomainSystemModelChangeHandler(IDomainSystemModel systemModel, int index, Guid id, IContext context);
}
