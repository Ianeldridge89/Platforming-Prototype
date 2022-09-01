using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int spawnPoint;
    // current scene
    public static int currentScene;
    public static double spawnTime;
    public static int playerScore;

    // collisions for moving to different scenes
    // coin information stored in a list 
    // list to store different spawn points
    // list to store different scene

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
        spawnPoint = 1;
        currentScene = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if scenenumber works
    }

    void SceneChange(int sceneNumber)
    {
        if (currentScene != sceneNumber)
        {
            currentScene = sceneNumber;
            if (currentScene == 1)
            {
                PlayerMovement.MovePlayer(74, 224);
            }

        }
    }

    

    [System.Serializable]
    class PlayerData
    {
        public int playerSpawn;
        public int currentScene;
        public double spawnTime;
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.playerSpawn = spawnPoint;
        data.currentScene = currentScene;
        data.spawnTime = Time.time;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("Game Saved: " + json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            spawnPoint = data.playerSpawn;
            currentScene = data.currentScene;
            spawnTime = data.spawnTime;
            Debug.Log("Game Loaded: " + json);
        }
    }

    public void coinCollected()
    {
        //score increases by 1. playerScore
        //
    }

    public void Menu()
    {

    }

/*
     * Title Screen
     * Main Menu
     * Leaderboard
     * LevellLoading
     * Level 1
     * Level 2 Loading
     * Level 2
     * Level 3 Loading
     * Level 3
     * Credits
*/

    public void startGame()
    {

    }


}
