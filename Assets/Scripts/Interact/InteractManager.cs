using System.Collections.Generic;
using UnityEngine;

public class InteractManager
{
    HashSet<ConditionKey> _conditionKeys = new();
    Dictionary<CharacterType, ConversationID> _storyDict = new();
    Dictionary<ConversationID, ConversationAsset> _assetDict = new();

    public InteractManager(ConversationList[] list)
    {
        foreach (var conversations in list)
        {
            _storyDict[conversations.TalkerType] = conversations.StartID;
            foreach (var conversation in conversations.Conversations)
            {
                _assetDict[conversation.ID] = conversation;
            }
        }
    }

    public void SetKey(ConditionKey conditionKey)
    {
        _conditionKeys.Add(conditionKey);
    }

    public void RemoveKey(ConditionKey conditionKey)
    {
        _conditionKeys.Remove(conditionKey);
    }

    public bool CheckCondition(Branch branch)
    {
        foreach (var condition in branch.Conditions)
        {
            if (!_conditionKeys.Contains(condition.ConditionKey)) return false;
        }
        return true;
    }

    public void Clear()
    {
        _conditionKeys.Clear();
    }

    public bool SetTalker(CharacterType characterType, out ConversationAsset asset)
    {
        asset = null;
        return _storyDict.TryGetValue(characterType, out var id) && _assetDict.TryGetValue(id, out asset);
    }

    public void UpdateID(CharacterType characterType, ConversationID id)
    {
        if (!_storyDict.ContainsKey(characterType)) return;
        _storyDict[characterType] = id;
    }
}
