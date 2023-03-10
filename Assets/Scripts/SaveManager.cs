using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string playerName;
    public string currentPlayerName;

    public int highScore = 0;

    // The code in Awake() creates a singleton that persists through different scenes
    private void Awake()
    {
        HiMark();

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

    public void LoadData()
    {
        string path = $"{Application.persistentDataPath}/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
    }

    public void HiMark()
    {
        Debug.Log("Hi Mark.");
        System.Console.WriteLine("Hi Matt.");
    }

}
