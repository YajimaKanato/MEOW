using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuModel", menuName = "Model/MenuModel")]
public class MenuModel : ScriptableObject, IModel<MenuRuntime>
{
    public MenuRuntime CreateRuntime()
    {
        return new MenuRuntime(this);
    }
}