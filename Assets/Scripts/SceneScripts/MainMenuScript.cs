using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public bool AButtonPressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("Main Menu Method Loaded");
        SceneManager.LoadScene("Assets/Scenes/LoadingScreens/Level1Loading.unity");
    }


}
