using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public bool canTalkTo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if canTalkTo is true, making a text box active above their heads and inactive when away from them.
        // if that's true and you press Talk, the textbox starts talking
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTalkTo = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalkTo = false;
    }
}
