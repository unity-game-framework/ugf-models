using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Models.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestModelControllerAsyncAsset")]
    public class TestModelControllerAsyncAsset : ModelControllerAsset
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new TestModelControllerAsync(arguments);
        }
    }

    public class TestModelControllerAsync : ModelControllerAsync<TestModel>
    {
        public TestModelControllerAsync(IApplication application) : base(application)
        {
        }

        protected override Task OnExecuteAsync(TestModel model, IContext context)
        {
            model.Value++;

            return Task.CompletedTask;
        }
    }
}
