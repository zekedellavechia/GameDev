using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) //can thrust 
        {
            print("Space is pressed");
        }

        else if (Input.GetKey(KeyCode.A)) // can rotate left
        {
            print("A is pressed");
        }
        else if (Input.GetKey(KeyCode.D)) //can rotate right
        {
            print("d is pressed");
        }
    }
}
