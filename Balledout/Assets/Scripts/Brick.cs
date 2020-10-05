using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int points = 100;
    public Vector3 rotator;
    public Material hitMaterial;

    Material orgMaterial;
    Renderer renderer;

    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y) * 0.1f);
        renderer = GetComponent<Renderer>();
        orgMaterial = renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        if(hits<=0)
        {
            GameManager.Instance.Score += points;
            Destroy(gameObject);
        }

        renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.5f);

    }

    void RestoreMaterial()
    {
        renderer.sharedMaterial = orgMaterial;
    }
}
