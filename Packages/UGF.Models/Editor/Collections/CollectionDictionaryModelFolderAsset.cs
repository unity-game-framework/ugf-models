using UGF.Assets.Editor;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UGF.Models.Runtime;
using UGF.Models.Runtime.Collections;
using UnityEditor;
using UnityEngine;

namespace UGF.Models.Editor.Collections
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Models/Collection Dictionary Model Folder", order = 2000)]
    public class CollectionDictionaryModelFolderAsset : AssetFolderAsset<CollectionDictionaryModelAsset, ModelAsset>
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

                Collection.Models.Add(new AssetIdReference<ModelAsset>(new GlobalId(guid), asset));
            }

            EditorUtility.SetDirty(Collection);
        }
    }
}
