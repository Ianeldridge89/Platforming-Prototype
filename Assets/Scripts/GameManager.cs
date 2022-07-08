using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int spawnPoint;
    // current scene
    public int currentScene;
    // collisions for moving to different scenes
    // coin information stored in a list 
    public Vector2 coinPos0;
    public Vector2 coinPos1;
    public Vector2 coinPos2;
    public Vector2 coinPos3;
    public Vector2 coinPos4;
    // list to store different spawn points
    public static List<Vector2> spawnPositions;
    public Vector2 spawnPos0;
    public Vector2 spawnPos1;
    public Vector2 spawnPos2;
    public Vector2 spawnPos3;
    public Vector2 spawnPos4;
    public Vector2 spawnPos5;
    public Vector2 spawnPos6;

    // list to store different scene
    public static List<int> scenes;
    public int scene0;
    public int scene1;
    public int scene2;
    public int scene3;

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
    }

    // Update is called once per frame
    void Update()
    {

    }


    [System.Serializable]
    class PlayerData
    {
        public int playerSpawn;
        public int currentScene;
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.playerSpawn = spawnPoint;
        data.currentScene = currentScene;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            currentScene = data.currentScene;
            spawnPoint = data.playerSpawn;
            
        }
    }



    public void Scene1Initialisation()
    {

    }


    public void Scene2Initialisation()
    {

    }

    public void Scene3Initialisation()
    {

    }
}
