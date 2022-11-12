using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Models.Runtime.Collections
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Collection List Model", order = 2000)]
    public class CollectionListModelAsset : ModelAsset
    {
        [AssetId]
        [SerializeField] private List<GlobalId> m_items = new List<GlobalId>();

        public List<GlobalId> Items { get { return m_items; } }

        protected override IModel OnBuild()
        {
            var model = new CollectionListModel();

            for (int i = 0; i < m_items.Count; i++)
            {
                GlobalId id = m_items[i];

                if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

                model.Items.Add(id);
            }

            return model;
        }
    }
}
