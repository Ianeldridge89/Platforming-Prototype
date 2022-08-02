using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !selected )
        {
            MainMenu();
        }
        
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu Method Loaded");
        selected = true;
        SceneManager.LoadSceneAsync("Assets/Scenes/Start/Main Menu.unity");
    }


}
