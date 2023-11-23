using UGF.Assets.Editor;
using UGF.Models.Runtime;
using UGF.Models.Runtime.Collections;
using UnityEditor;
using UnityEngine;

namespace UGF.Models.Editor.Collections
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Collection List Model Folder", order = 2000)]
    public class CollectionListModelFolderAsset : AssetFolderAsset<CollectionListModelAsset, ModelAsset>
    {
        protected override void OnUpdate()
        {
            Collection.Models.Clear();

            string[] guids = FindAssetsAsGuids();

            for (int i = 0; i < guids.Length; i++)
            {
                string guid = guids[i];
                string path = AssetDatabase.GUIDToAssetPath(guid);

                var asset = AssetDatabase.LoadAssetAtPath<ModelAsset>(path);

                Collection.Models.Add(asset);
            }

            EditorUtility.SetDirty(Collection);
        }
    }
}
