using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] //Does not allow multiple components
public class Oscillator : MonoBehaviour
{

    // Start is called before the first frame update

 
    [SerializeField] Vector3 movementVector;

    //todo remove from inspector later

    [Range(0, 1)]  [SerializeField] float movementFactor; //-10 to 10

    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //set movement factor
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
