using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;

    public float MovementSpeed = 10;

    void Start()
    {
        Instance = this; 
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + MovementSpeed * Time.fixedDeltaTime, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + -MovementSpeed * Time.fixedDeltaTime, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x + -MovementSpeed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + MovementSpeed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
        }
    }
}
