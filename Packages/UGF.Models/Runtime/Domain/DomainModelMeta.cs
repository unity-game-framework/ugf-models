using System;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModelMeta : IDomainModelMeta
    {
        public IProvider<IModel, string> Ids { get; }

        public DomainModelMeta() : this(new Provider<IModel, string>())
        {
        }

        public DomainModelMeta(IProvider<IModel, string> ids)
        {
            Ids = ids ?? throw new ArgumentNullException(nameof(ids));
        }
    }
}
