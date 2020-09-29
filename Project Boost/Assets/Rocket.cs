using UnityEngine; //namespaces
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    public float levelLoadDelay;
    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip dead;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deadParticles;

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
    { if (state==State.Alive)
        {
            RespondToThrustInput();
            Rotate();
        }
    }

    private void OnCollisionEnter(Collision collision)  // Type Collision . Variable collision 
    {
        if (state !=State.Alive) { return; }
     

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
                break;
        }

    
    }


    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        Invoke("LoadNextScene", levelLoadDelay);
    }
    private void StartDeathSecuence()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(dead);
     
        deadParticles.Play();
        Invoke("RestartLevel", levelLoadDelay);
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    private void RespondToThrustInput()
    {
        
        if (Input.GetKey(KeyCode.Space)) //can thrust while rotating
        {
            ApplyThrust();
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }
    private void ApplyThrust()
    {

        rb.AddRelativeForce(Vector3.up * mainThrust);

        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        mainEngineParticles.Play();

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
