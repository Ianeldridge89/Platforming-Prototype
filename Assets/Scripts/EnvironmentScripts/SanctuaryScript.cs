using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanctuaryScript : MonoBehaviour
{
    public bool inThisSanctuary;
    public int countdownTime;
    public Vector3 sanctuaryPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        inThisSanctuary = false;
        sanctuaryPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EnterThisSanctuary();

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ExitThisSanctuary();
        }
    }

    public void EnterThisSanctuary()
    {
        inThisSanctuary = true;
        GameManager.inSanctuary = true;
        GameManager.InTheSanctuary(countdownTime);
        GameManager.respawnPosition = sanctuaryPosition;
    }

    public void ExitThisSanctuary()
    {
        inThisSanctuary = false;
        GameManager.exitSanctuaryTime = Time.time;
        GameManager.currentSanctuaryTime = countdownTime;
        GameManager.inSanctuary = false;

    }
}
