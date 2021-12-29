﻿using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Models.Runtime.Domain
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Domain Model Execute Controller Async", order = 2000)]
    public class DomainModelExecuteControllerAsyncAsset : ModelControllerDescribedAsset<DomainModelExecuteControllerAsync, DomainModelExecuteControllerDescription>
    {
        [SerializeField] private List<DomainModelExecuteControllerAsset.EntryData> m_modelControllers = new List<DomainModelExecuteControllerAsset.EntryData>();

        public List<DomainModelExecuteControllerAsset.EntryData> ModelControllers { get { return m_modelControllers; } }

        [Serializable]
        public struct EntryData
        {
            [AssetGuid(typeof(ModelAsset))]
            [SerializeField] private string m_model;
            [AssetGuid(typeof(ModelController))]
            [SerializeField] private string m_controller;

            public string Model { get { return m_model; } set { m_model = value; } }
            public string Controller { get { return m_controller; } set { m_controller = value; } }
        }

        protected override DomainModelExecuteControllerDescription OnBuildDescription()
        {
            var description = new DomainModelExecuteControllerDescription();

            for (int i = 0; i < m_modelControllers.Count; i++)
            {
                DomainModelExecuteControllerAsset.EntryData data = m_modelControllers[i];

                if (string.IsNullOrEmpty(data.Model)) throw new ArgumentException("Value cannot be null or empty.", nameof(data.Model));
                if (string.IsNullOrEmpty(data.Controller)) throw new ArgumentException("Value cannot be null or empty.", nameof(data.Controller));

                description.ModelControllerIds.Add((data.Model, data.Controller));
            }

            return description;
        }

        protected override DomainModelExecuteControllerAsync OnBuild(DomainModelExecuteControllerDescription description, IApplication application)
        {
            return new DomainModelExecuteControllerAsync(description, application);
        }
    }
}
