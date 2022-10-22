﻿using System;
using UGF.Application.Runtime;
using UGF.Module.Controllers.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Models.Runtime.Domain.Systems
{
    public abstract class DomainSystemModelController<TDescription> : ModelControllerDescribed<TDescription, IDomainSystemModel> where TDescription : class, IControllerDescription
    {
        protected DomainSystemModelController(TDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnExecute(IDomainSystemModel systemModel, IContext context)
        {
            var domainModel = context.Get<IDomainModel>();

            for (int i = 0; i < systemModel.ModelIds.Count; i++)
            {
                Guid id = systemModel.ModelIds[i];
                IModel model = domainModel.Get(id);

                OnExecute(systemModel, id, model, context);
            }
        }

        protected abstract void OnExecute(IDomainSystemModel systemModel, Guid id, IModel model, IContext context);
    }
}
