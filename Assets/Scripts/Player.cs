using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;

    float speed = 10f;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Input.GetKey(left))
        {
            rigidBody.AddForce(new Vector2(-10f, 0f));
        }
        if (Input.GetKey(left))
        {
            rigidBody.AddForce(new Vector2(10f, 0f));
        }
    }
}
