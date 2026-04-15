using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "HotbarModel", menuName = "Model/HotbarModel")]
public class HotbarModel : ScriptableObject, IModel<HotbarRuntime>
{
    [SerializeField] ItemBase[] _hotbar;
    [SerializeField, Min(0)] int _defaultIndex = 0;

    public ItemBase[] Hotbar => _hotbar;
    public int DefaultIndex => _defaultIndex;

    public HotbarRuntime CreateRuntime()
    {
        return new HotbarRuntime(this);
    }

    private void OnValidate()
    {
        var length = 6;
        if (_hotbar == null || _hotbar.Length != length)
        {
            System.Array.Resize(ref _hotbar, length);
        }
    }
}