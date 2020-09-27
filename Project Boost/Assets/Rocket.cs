using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) //can thrust while rotating
        {
            rb.AddRelativeForce(Vector3.up);
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        

        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(-Vector3.forward);
        }

   
    }
}
