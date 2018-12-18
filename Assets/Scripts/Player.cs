using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerNum { playerOne, playerTwo }

// TODO: Make movement framerate independent

public class Player : MonoBehaviour
{
    float speed = 20f;

    float speedLimit = 10f;

    float jumpSpeed = 500f;

    bool CurrentlyJumping;

    Rigidbody2D rigidBody;

    PlayerInput playerInputManager;

    [SerializeField] playerNum playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerInputManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LimitSpeed();
        Jumping();
    }

    void Movement()
    {
        string dir = playerInputManager.MoveDir(playerNumber);
        if(Input.GetAxis(dir) < 0)
        {
            rigidBody.AddForce(new Vector2(-speed, 0f));
        }
        else if (Input.GetAxis(dir) > 0)
        {
            rigidBody.AddForce(new Vector2(speed, 0f));
        }
        // Decelerate when no buttons are pressed and velocity isn't zero
        else if (rigidBody.velocity.x != 0)
        {
            rigidBody.AddForce(new Vector2(-rigidBody.velocity.x * 8f, 0f));
        }

    }

    void LimitSpeed()
    {
        // Player1 Speed limit
        if(rigidBody.velocity.x > speedLimit)
        {
            rigidBody.velocity = new Vector2(speedLimit, rigidBody.velocity.y);
        }
        else if(rigidBody.velocity.x < -speedLimit)
        {
            rigidBody.velocity = new Vector2(-speedLimit, rigidBody.velocity.y);
        }
    }

    void Jumping()
    {

        // First check if the player can jump
        if (PlayerCanJump())
        {
            // Ask the player input for the button to use
            string jump = playerInputManager.Jump(playerNumber);
            if (Input.GetButtonDown(jump))
            {
                StartCoroutine(JumpingCoroutine(jump));
            }
        }
    }

    IEnumerator JumpingCoroutine(string jump)
    {
        // Keep track of the initial position, and if they're currently jumping
        // Wait until the next fixed update to apply force
        Vector2 initialJump = transform.position;
        yield return new WaitForFixedUpdate();
        rigidBody.AddForce(new Vector2(0f, jumpSpeed));
        CurrentlyJumping = true;

        while (CurrentlyJumping)
        {
            // If velocity in the Y direction becomes zero break out of the loop
            if (rigidBody.velocity.y < 0 || transform.position.y >= initialJump.y + 4f)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
                CurrentlyJumping = false;
            }

            // Otherwise, if they stop holding space set velocity to zero and break out
            else if (Input.GetButtonUp(jump))
            {

                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
                CurrentlyJumping = false;
            }
            yield return null;
        }


    }

    bool PlayerCanJump()
    {
        Vector2 playerBottom = new Vector2(GetComponent<CapsuleCollider2D>().bounds.min.x, GetComponent<CapsuleCollider2D>().bounds.min.y - .01f);
        if (Physics2D.Raycast(playerBottom, Vector2.down, .2f))
            return true;

        else
            return false;
    }

}
