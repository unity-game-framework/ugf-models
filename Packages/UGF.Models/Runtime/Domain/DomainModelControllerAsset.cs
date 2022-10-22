using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model Controller", order = 2000)]
    public class DomainModelControllerAsset : ModelControllerDescribedAsset<DomainModelController, DomainModelControllerDescription>
    {
        [SerializeField] private List<EntryData> m_controllers = new List<EntryData>();

        public List<EntryData> Controllers { get { return m_controllers; } }

        [Serializable]
        public struct EntryData
        {
            [AssetId(typeof(ModelAsset))]
            [SerializeField] private GlobalId m_model;
            [AssetId(typeof(ModelControllerAsset))]
            [SerializeField] private GlobalId m_controller;

            public GlobalId Model { get { return m_model; } set { m_model = value; } }
            public GlobalId Controller { get { return m_controller; } set { m_controller = value; } }
        }

        protected override DomainModelControllerDescription OnBuildDescription()
        {
            var description = new DomainModelControllerDescription();

            for (int i = 0; i < m_controllers.Count; i++)
            {
                EntryData data = m_controllers[i];

                if (!data.Model.IsValid()) throw new ArgumentException("Value should be valid.", nameof(data.Model));
                if (!data.Controller.IsValid()) throw new ArgumentException("Value should be valid.", nameof(data.Controller));

                description.ModelControllerIds.Add((data.Model, data.Controller));
            }

            return description;
        }

        protected override DomainModelController OnBuild(DomainModelControllerDescription description, IApplication application)
        {
            return new DomainModelController(description, application);
        }
    }
}
