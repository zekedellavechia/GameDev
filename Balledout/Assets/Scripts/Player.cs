using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //moveposition for interpolation
        rb.MovePosition(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 50)).x, -17, 0));
    }
}
