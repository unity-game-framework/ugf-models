namespace UGF.Models.Runtime
{
    public interface IModelCopyable : IModel
    {
        void CopyFrom(IModel model);
    }
}
