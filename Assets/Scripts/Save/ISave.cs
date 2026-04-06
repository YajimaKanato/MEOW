using UnityEngine;

public interface ISave
{
    void Save(SaveClass save);
    void Load(SaveClass save, bool loaded);
}
