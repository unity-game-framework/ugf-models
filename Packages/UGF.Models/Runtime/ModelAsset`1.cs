namespace UGF.Models.Runtime
{
    public abstract class ModelAsset<TModel> : ModelAsset where TModel : IModel
    {
        protected override IModel OnBuild()
        {
            return OnBuildTyped();
        }

        protected abstract TModel OnBuildTyped();
    }
}
