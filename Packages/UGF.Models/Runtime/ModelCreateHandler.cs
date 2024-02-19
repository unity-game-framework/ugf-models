namespace UGF.Models.Runtime
{
    public delegate T ModelCreateHandler<out T>() where T : IModel;
}
