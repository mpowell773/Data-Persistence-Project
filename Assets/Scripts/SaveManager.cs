using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string playerName;
    public int highScore = 0;

    // The code in Awake() creates a singleton that persists through different scenes
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    //------------------Save Data Class and Functions------------------\\
    [System.Serializable]
    class SavedData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
    }

}
