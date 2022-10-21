using System;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelMeta : IDomainModelMeta
    {
        public IProvider<IModel, Guid> Ids { get; }

        public DomainModelMeta() : this(new Provider<IModel, Guid>())
        {
        }

        public DomainModelMeta(IProvider<IModel, Guid> ids)
        {
            Ids = ids ?? throw new ArgumentNullException(nameof(ids));
        }
    }
}
