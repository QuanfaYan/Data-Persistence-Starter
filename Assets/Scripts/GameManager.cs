using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private string gameDataName = "gameData.json";
    public static GameManager instance;
    public string playerName;
    public int bestScore = 0;
    public string bestScoreOwner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        LoadGameData();
    }

    [Serializable]
    class GameData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveGameData()
    {
        GameData data = new GameData();
        data.playerName = bestScoreOwner;
        data.bestScore = bestScore;
        String json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/" + gameDataName, json);
    }

    public void LoadGameData()
    {
        String path = Application.persistentDataPath + "/" + gameDataName;
        if(File.Exists(path))
        {
            String json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            bestScoreOwner = data.playerName;
            bestScore = data.bestScore;
        }
        else
        {
            Debug.Log("no game data");
        }
    }
}
