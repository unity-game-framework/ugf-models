using System;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public delegate void DomainModelChangeHandler(IDomainModel domainModel, Guid id, IModel model, IContext context);
}
