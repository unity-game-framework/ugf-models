using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Models.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestModelControllerAsset")]
    public class TestModelControllerAsset : ModelControllerAsset
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new TestModelController(arguments);
        }
    }

    public class TestModelController : ModelController<TestModel>
    {
        public TestModelController(IApplication application) : base(application)
        {
        }

        protected override void OnExecute(TestModel model, IContext context)
        {
            model.Value++;
        }
    }
}
