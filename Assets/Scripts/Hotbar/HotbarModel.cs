using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "HotbarModel", menuName = "Model/HotbarModel")]
public class HotbarModel : ScriptableObject, IModel<HotbarRuntime>
{
    [SerializeField] ItemBase[] _hotbar;

    public ItemBase[] Hotbar => _hotbar;

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