using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

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
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)  // Type Collision . Variable collision 
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Collide with Friendly");
                break;
            case "Respawn":
                print("Collide with Respawn");
                break;
            default:
                print("Death"); //todo Kill the Player
                break;
        }
    }

    private void Thrust()
    {
        
        if (Input.GetKey(KeyCode.Space)) //can thrust while rotating
        {
            rb.AddRelativeForce(Vector3.up * mainThrust);
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
    private void Rotate()
    {
        rb.freezeRotation = true; //take manual control of rotation

     
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rb.freezeRotation = false; //resumes physics
    }
}
