using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;

namespace UGF.Models.Runtime.Collections
{
    public abstract class CollectionListModelControllerAsset<TModel> : ModelControllerAsset where TModel : IModel
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new CollectionListModelController<TModel>(arguments);
        }
    }
}
