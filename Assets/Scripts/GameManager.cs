using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] public static int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PointScored(int pointValue)
    {
        
    }


}
