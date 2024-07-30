using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string nickname;
    public int highScore;
    public string bestNickname;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }
    [System.Serializable]
    class SaveData
    {
        public string bestNickname;
        public int highscore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestNickname = bestNickname;
        data.highscore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestNickname = data.bestNickname;
            highScore = data.highscore;
        }
    }
}
