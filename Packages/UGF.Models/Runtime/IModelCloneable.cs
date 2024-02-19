namespace UGF.Models.Runtime
{
    public interface IModelCloneable : IModel
    {
        IModel Clone();
    }
}
