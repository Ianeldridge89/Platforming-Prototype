using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1LoadingScript : MonoBehaviour
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
        if (Input.anyKeyDown && (startTime + 5 < Time.time))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        Debug.Log("Level 1 Loaded");

    }

}
