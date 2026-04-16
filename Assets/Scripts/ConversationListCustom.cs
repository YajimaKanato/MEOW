using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ConversationList))]
public class ConversationListCustom : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Asset収集"))
        {
            var conversationList = (ConversationList)target;
            string[] guids = AssetDatabase.FindAssets("t:ConversationAsset", new string[] { "Assets/ScriptableObjects/ConversationAssets" });
            var array = guids
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .Select(path => AssetDatabase.LoadAssetAtPath<ConversationAsset>(path))
                .Where(data => data != null)
                .Where(data => data.CharacterType == conversationList.TalkerType)
                .OrderBy(data => data.CharacterType + data.ID)
                .ToArray();

            Undo.RecordObject(conversationList, "Auto Collection Asset");
            conversationList.SetConversation(array);
            EditorUtility.SetDirty(conversationList);
        }
    }
}
