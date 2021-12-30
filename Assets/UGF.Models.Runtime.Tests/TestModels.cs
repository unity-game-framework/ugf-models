﻿using NUnit.Framework;
using UGF.Application.Runtime;
using UGF.Models.Runtime.Domain;
using UGF.Module.Controllers.Runtime;
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