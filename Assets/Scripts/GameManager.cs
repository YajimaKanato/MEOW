using MVPTools.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnDestroy()
    {
        RuntimeStorage.ClearData();
#if UNITY_EDITOR
        Debug.Log("RuntimeStorage Cleared");
#endif
    }
}
