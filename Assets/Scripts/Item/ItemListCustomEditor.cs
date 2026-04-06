using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemList))]
public class ItemListCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("アイテム収集"))
        {
            ItemList itemList = (ItemList)target;
            var guids = AssetDatabase.FindAssets("t:ItemBase", new string[] { "Assets/ScriptableObjects/Item" });

            var array = guids
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .Select(path => AssetDatabase.LoadAssetAtPath<ItemBase>(path))
                .Where(data => data != null)
                .OrderBy(data => data.ItemLabel)
                .ToArray();

            Undo.RecordObject(itemList, "Collect Item");
            itemList.SetItems(array);
            EditorUtility.SetDirty(itemList);
            Debug.Log("アイテム収集完了");
        }

        DrawDefaultInspector();
    }
}
