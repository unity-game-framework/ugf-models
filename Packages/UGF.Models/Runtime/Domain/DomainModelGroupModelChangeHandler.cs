using System;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain
{
    public delegate void DomainModelGroupModelChangeHandler(DomainModelGroupModel groupModel, Guid key, Guid value, IContext context);
}
