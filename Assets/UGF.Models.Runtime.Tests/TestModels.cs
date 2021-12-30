using NUnit.Framework;
using UGF.Application.Runtime;
using UGF.Models.Runtime.Domain;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Models.Runtime.Tests
{
    public class TestModels
    {
        [Test]
        public void InitializeAndUninitialize()
        {
            IApplication application = CreateApplication();

            application.Initialize();

            var controller = application.GetController<IDomainModelOperatorController>();

            Assert.NotNull(controller);

            application.Uninitialize();
        }

        [Test]
        public void Execute()
        {
            IApplication application = CreateApplication();
            var asset = Resources.Load<DomainModelAsset>("DomainModel");
            var domainModel = asset.Build<IDomainModel>();
            var model = domainModel.Get<TestModel>("c7ec7dee8c761684ebb0e85d3f6189c3");
            var context = new Context { application };

            application.Initialize();

            var controller = application.GetController<IModelController>("b148c8ecb988147488302960be6c74ca");

            Assert.AreEqual(0, model.Value);

            controller.Execute(domainModel, context);

            Assert.AreEqual(1, model.Value);

            application.Uninitialize();
        }

        private IApplication CreateApplication()
        {
            return new ApplicationConfigured(new ApplicationResources
            {
                new ApplicationConfig
                {
                    Modules =
                    {
                        (IApplicationModuleBuilder)Resources.Load("Module", typeof(IApplicationModuleBuilder))
                    }
                }
            });
        }
    }
}
