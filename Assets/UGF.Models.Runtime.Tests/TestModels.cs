using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Models.Runtime.Domain;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Tasks;
using UnityEngine;
using UnityEngine.TestTools;

namespace UGF.Models.Runtime.Tests
{
    public class TestModels
    {
        [Test]
        public void InitializeAndUninitialize()
        {
            IApplication application = CreateApplication();

            application.Initialize();
            application.Uninitialize();
        }

        [Test]
        public void Execute()
        {
            IApplication application = CreateApplication();
            var asset = Resources.Load<DomainModelAsset>("DomainModel");
            var domainModel = asset.Build<IDomainModel>();
            var model = domainModel.Get<TestModel>(new Guid("c7ec7dee8c761684ebb0e85d3f6189c3"));
            var context = new Context { application };

            application.Initialize();

            var controller = application.GetController<IModelController>(new GlobalId("f6ac719deafe29d4eb07bc6bc6d19b24"));

            Assert.AreEqual(0, model.Value);

            controller.Execute(domainModel, context);

            Assert.AreEqual(1, model.Value);

            application.Uninitialize();
        }

        [UnityTest]
        public IEnumerator ExecuteAsync()
        {
            IApplication application = CreateApplication();
            var asset = Resources.Load<DomainModelAsset>("DomainModel");
            var domainModel = asset.Build<IDomainModel>();
            var model = domainModel.Get<TestModel>(new Guid("c7ec7dee8c761684ebb0e85d3f6189c3"));
            var context = new Context { application };

            application.Initialize();

            var controller = application.GetController<IModelControllerAsync>(new GlobalId("1b9beffa738e10344b87b5401b988ac1"));

            Assert.AreEqual(0, model.Value);

            Task task = controller.ExecuteAsync(domainModel, context);

            yield return task.WaitCoroutine();

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
