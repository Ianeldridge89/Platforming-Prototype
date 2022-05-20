using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Health Bar")]
    public float health;
    //public TextMeshProUGUI healthText;
    //public TextMeshProUGUI gameOverText;

    


    // Start is called before the first frame update
    void Start()
    {
        //healthText.text = "Health " + health;

    }

    // Update is called once per frame
    void Update()
    {
        //health = PlayerCombat.playerHealth;
        //healthText.text = "Health " + health;
        //if (!PlayerCombat.isAlive)
        //{
            //GameOver();
        //}
    }

    //public void GameOver()
    //{
        //healthText.gameObject.SetActive(false);
        //gameOverText.gameObject.SetActive(true);
    //}


    


}
