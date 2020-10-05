using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float speed = 20f;
    Rigidbody rb;
    Vector3 velocity;
    Renderer renderer;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
    }

    void Launch()
    {
        rb.velocity = Vector3.up * speed;
    }

    void FixedUpdate()
    {
        //normalize 
        rb.velocity = rb.velocity.normalized * speed;
        velocity = rb.velocity;

        if (!renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //reflect when it hits
        rb.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }
}


