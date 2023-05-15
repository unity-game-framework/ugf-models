using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;

namespace UGF.Models.Runtime.Collections
{
    public abstract class CollectionDictionaryModelControllerAsset<TModel> : ModelControllerAsset where TModel : IModel
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new CollectionDictionaryModelController<TModel>(arguments);
        }
    }
}
