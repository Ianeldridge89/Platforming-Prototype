using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int spawnPoint;
    // current scene
    public static int currentScene;
    public static double spawnTime;
    public static int playerScore;

    // Sanctuary
    public static float playerTime;
    public static bool inSanctuary;
    public static float currentSanctuaryTime;
    public static float exitSanctuaryTime;
    public static float timeRemaining;
    public static Vector3 respawnPosition; 
    public TextMeshProUGUI playerTimeRemaining;    
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
        inSanctuary = false;
        currentSanctuaryTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inSanctuary)
        {
            CountDownTimer();
        }
        CountdownText();
        //check to see if scenenumber works
    }

    void SceneChange(int sceneNumber)
    {
        currentScene = sceneNumber;
        if (currentScene == 1)
        {
            //add this back in later its only out for TESTING
            //just uncomment it
            //oh and add the spawn positions for the other scenes;
            Debug.Log("Current Scene is Scene 1");
            //PlayerMovement.MovePlayer(74, 224);
        }
        else if (currentScene == 2)
        {
            //Debug.Log("Current SCene is Scene 2");
        }
        else if (currentScene == 3)
        {
            //Debug.Log("Current SCene is Scene 3");
        }        
    }

    public static void InTheSanctuary(float newTime)
    {
        // this is where the new information from thesanctuary is recorded
        // its recorded because we need to figure out how to do: CountDownTimer.
        inSanctuary = true;
        playerTime = newTime;
    }

    public static void CountDownTimer()
    {
        //Debug.Log("the countdown timer in GameManager is vibin'");THIS IS WORKING BABYYEEEE
        //playerTime lowers until it gets to 0
        playerTime = (exitSanctuaryTime + currentSanctuaryTime) - Time.time;
        if (playerTime <= 0)
        {
            RespawnPlayer();
        }
    }

    public static void RespawnPlayer()
    {
        Debug.Log("RespawnPlayer method activated");
        PlayerMovement.MovePlayer(respawnPosition.x, respawnPosition.y);
        InTheSanctuary(currentSanctuaryTime);
    }

    public void CountdownText()
    {
        int playerTimeInt = (int) playerTime; 
        playerTimeRemaining.text = "time left " + playerTimeInt;
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

    public void CoinCollected()
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

    public void StartGame()
    {

    }


}
