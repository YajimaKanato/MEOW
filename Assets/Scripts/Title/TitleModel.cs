using MVPTools.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "TitleModel", menuName = "Model/TitleModel")]
public class TitleModel : ScriptableObject, IModel<TitleRuntime>
{
    public TitleRuntime CreateRuntime()
    {
        return new TitleRuntime(this);
    }
}