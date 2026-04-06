using Cysharp.Threading.Tasks;
using System.IO;
using UnityEngine;

public static class SaveAndLoad
{
    const string JSON = ".json";

    /// <summary>
    /// Json形式でデータをセーブする関数
    /// </summary>
    /// <typeparam name="T">セーブするデータの型</typeparam>
    /// <param name="fileName">セーブするファイルの名前</param>
    /// <param name="saveData">セーブするデータ</param>
    public static void SaveData<T>(string fileName, T saveData)
    {
        try
        {
#if UNITY_WEBGL
                PlayerPrefs.SetString(fileName, JsonUtility.ToJson(saveData));
                PlayerPrefs.Save();
#else
            var filePath = Path.Combine(Application.persistentDataPath, fileName + JSON);
            var path = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(filePath, json);
#endif
            Debug.Log("セーブ完了");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    /// <summary>
    /// Json形式でデータをロードする関数
    /// </summary>
    /// <typeparam name="T">ロードするデータの型</typeparam>
    /// <param name="fileName">ロードするファイルの名前</param>
    /// <returns></returns>
    public static bool LoadData<T>(string fileName, out T result)
    {
        result = default;
        var filePath = Path.Combine(Application.persistentDataPath, fileName + JSON);

#if UNITY_WEBGL
            if (!PlayerPrefs.HasKey(fileName))
            {
                Debug.LogWarning("ファイルが見つかりませんでした");
                return false;
            }

            try
            {
                var json = PlayerPrefs.GetString(fileName);
                result = JsonUtility.FromJson<T>(json);
                return true;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
                return false;
            }
#else
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("ファイルが見つかりませんでした");
            return false;
        }

        try
        {
            var json = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(json)) return false;
            result = JsonUtility.FromJson<T>(json);
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            return false;
        }
#endif
    }

    public static void DeleteData(string fileName)
    {
        try
        {
#if UNITY_WEBGL
                if (PlayerPrefs.HasKey(fileName))
                {
                    PlayerPrefs.DeleteKey(fileName);
                    PlayerPrefs.Save();
                    Debug.Log("セーブ削除完了");
                }
                else
                {
                    Debug.LogWarning("削除対象が存在しません");
                }
#else
            var filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Debug.Log("セーブ削除完了");
            }
            else
            {
                Debug.LogWarning("削除対象が存在しません");
            }
#endif
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    public static async UniTask SaveDataAsync<T>(string fileName, T saveData)
    {
        try
        {
#if UNITY_WEBGL
                PlayerPrefs.SetString(fileName, JsonUtility.ToJson(saveData));
                PlayerPrefs.Save();
#else
            var filePath = Path.Combine(Application.persistentDataPath, fileName + JSON);

            var dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var json = JsonUtility.ToJson(saveData, true);

            await UniTask.SwitchToThreadPool();
            File.WriteAllText(filePath, json);
            await UniTask.SwitchToMainThread();
#endif
            Debug.Log("セーブ完了");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    public static async UniTask<(bool success, T data)> LoadDataAsync<T>(string fileName)
    {
#if UNITY_WEBGL
            if (!PlayerPrefs.HasKey(fileName))
                return (false, default);

            try
            {
                var json = PlayerPrefs.GetString(fileName);
                return (true, JsonUtility.FromJson<T>(json));
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
                return (false, default);
            }
#else
        var filePath = Path.Combine(Application.persistentDataPath, fileName + JSON);

        if (!File.Exists(filePath))
            return (false, default);

        try
        {
            string json;

            await UniTask.SwitchToThreadPool();
            json = File.ReadAllText(filePath);
            await UniTask.SwitchToMainThread();

            if (string.IsNullOrEmpty(json))
                return (false, default);

            var result = JsonUtility.FromJson<T>(json);
            return (true, result);
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            return (false, default);
        }
#endif
    }

    public static async UniTask DeleteDataAsync(string fileName)
    {
        try
        {
#if UNITY_WEBGL
                if (PlayerPrefs.HasKey(fileName))
                {
                    PlayerPrefs.DeleteKey(fileName);
                    PlayerPrefs.Save();
                    Debug.Log("セーブ削除完了");
                }
                else
                {
                    Debug.LogWarning("削除対象が存在しません");
                }
#else
            var filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");

            if (File.Exists(filePath))
            {
                await UniTask.SwitchToThreadPool();
                File.Delete(filePath);
                await UniTask.SwitchToMainThread();
                Debug.Log("セーブ削除完了");
            }
            else
            {
                Debug.LogWarning("削除対象が存在しません");
            }
#endif
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }
}
