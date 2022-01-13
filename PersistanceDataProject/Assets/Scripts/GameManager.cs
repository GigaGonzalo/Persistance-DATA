using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string namPla;
    public int higScore;

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

    [System.Serializable]
    class SaveData
    {
        public string namepla;
        public int score;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.namepla = namPla;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public string LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //namPla = data.namepla;

            return data.namepla;
        }
        else
        {
            return "null";
        }
    }
    public void SaveScore(int actualScore)
    {
        if (actualScore > LoadScore()) {
            Debug.Log("Entre a SaveScore " + actualScore);
            SaveData data = new SaveData();
            data.score = actualScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefileScore.json", json);

            SaveName();
        }
    }
    public int LoadScore()
    {
        string path = Application.persistentDataPath + "/savefileScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Entre a LoadScore " + data.score);
            //namPla = data.namepla;

            return data.score;
        }
        else
        {
            return 0;
        }
    }
}
