using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1EntryScript : MonoBehaviour
{
    public BoxCollider2D entryCollider;
    public bool entered;
    public int sceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        entryCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        EntryBehaviour();

    }

    public void EntryBehaviour()
    {
        SceneManager.LoadScene("Assets/Scenes/LoadingScreens/Level1Loading.unity");
        GameManager.currentScene = 1;

    }
}
