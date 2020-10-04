using System;
using UnityEngine; //namespaces
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [Range(0, 5)] public float levelLoadDelay;
    //public Rigidbody disparo;


    bool isThrusting = false;
    //enum State { Alive, Dying, Transcending }  replaced by istransitioning
    //State state = State.Alive;  replaced by istransitioning

    bool isTransitioning = false;



    [SerializeField] [Range(50, 300)] float rcsThrust;
    [SerializeField] [Range(50, 300)] float mainThrust;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip dead;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deadParticles;

    bool collisionsDisabled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextScene();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionsDisabled = !collisionsDisabled;
        }
    }

    void Update()
    {
        ProcessInput();

        //aca meti mano
       // if (Input.GetKeyDown(KeyCode.C))
       // {
       //     Instantiate(disparo);
        //}
       
    }


    private void ProcessInput()
    { if (!isTransitioning)
        {
            RespondToThrustInput();
            Rotate();
        }
        if (Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }

    }

    private void RespondToThrustInput()
    {
        isThrusting = Input.GetKey(KeyCode.Space);

        if (isThrusting)
        {
            ApplyThrustEffects();
        }
        else
        {
            StopApplyingThrust();
        }
    }

    private void ApplyThrustEffects()
    {

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        mainEngineParticles.Play();

    }

    private void FixedUpdate()
    {
        if (isThrusting)
        {
            rb.AddRelativeForce(Vector3.up * mainThrust, ForceMode.Acceleration);
        }
    }



    private void StopApplyingThrust()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }


   

    private void OnCollisionEnter(Collision collision)  // Type Collision . Variable collision 
    {
        if (isTransitioning || collisionsDisabled ) { return; }


        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Collide with Friendly");
                break;
            case "Respawn":
                print("Collide with Respawn");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSecuence();
                //todo agregar un destroy
                
                break;
        }

    
    }


    private void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        Invoke("LoadNextScene", levelLoadDelay);
    }
    private void StartDeathSecuence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(dead);
        deadParticles.Play();
        Invoke("RestartLevel", levelLoadDelay);
    }
    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; //LoopBackToStart
        }
        SceneManager.LoadScene(nextSceneIndex);
  
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }


  
    private void Rotate()
    {
        rb.angularVelocity = Vector3.zero;

     
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }


    }
}
