namespace UGF.Models.Runtime
{
    public delegate T ModelCreateHandler<T>(T model) where T : IModel;
}
