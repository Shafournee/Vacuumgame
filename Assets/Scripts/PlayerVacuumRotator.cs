using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVacuumRotator : MonoBehaviour
{
    PlayerInput playerInputManager;
    float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
        playerInputManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateHead();
    }

    void RotateHead()
    {
        string xAxis = "Mouse X";
        string yAxis = "Mouse Y";
        string xRight = "RightH";
        string yRight = "RightV";

        float angle = Mathf.Atan(Input.GetAxis(yRight) / Input.GetAxis(xRight)) * Mathf.Rad2Deg;

        Debug.Log(angle);

        Debug.Log(Input.GetAxis(xRight));
        transform.rotation = new Quaternion(0f, 0f, angle, 0f);
    }
}
