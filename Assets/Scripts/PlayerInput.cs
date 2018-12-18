using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Give the player their movement direction
    public string MoveDir(playerNum p)
    {
        if (p == playerNum.playerOne)
        {
            return "Horizontal1";
        }
        else
        {
            return "Horizontal";
        }
    }

    // The player will ask if they can jump, tell them if they can or not
    public string Jump(playerNum p)
    {
        if (p == playerNum.playerOne)
        {
            return "Jump1";
        }
        else
        {
            return "Jump";
        }

    }


    
}
