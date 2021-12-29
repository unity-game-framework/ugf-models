using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Models.Runtime.Domain
{
    public interface IDomainModelMeta
    {
        IProvider<IModel, string> Ids { get; }
    }
}
