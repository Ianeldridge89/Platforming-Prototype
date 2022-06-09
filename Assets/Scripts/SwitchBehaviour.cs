using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    SpriteRenderer switchColor;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        switchColor = GetComponent<SpriteRenderer>();
        switchColor.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchFlip()
    {
        if (isActive)
        {
            isActive = false;
            switchColor.color = Color.red;
        }
        else if (!isActive)
        {
            isActive = true;
            switchColor.color = Color.green;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Projectile"))
        {
            SwitchFlip();
        }
    }

}
