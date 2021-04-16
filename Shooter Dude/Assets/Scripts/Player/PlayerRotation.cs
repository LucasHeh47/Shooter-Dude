using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 diff = mousePos - (Vector2)transform.position;

        //use tranform.up if the sprite is drawn with the forward at the top
        transform.up = diff;

        //tweak this part inside the if or in the flipX / flipY because i'm not sure of the values
        if(diff.x <= 0)
        {
            gun.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gun.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
