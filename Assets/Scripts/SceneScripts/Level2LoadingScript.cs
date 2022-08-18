using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2LoadingScript : MonoBehaviour
{
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        
        Debug.Log("Level 2 Loaded");
        SceneManager.LoadScene("Assets/Scenes/Levels/Level 2.unity");
    }

}
