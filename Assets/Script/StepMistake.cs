using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StepMistake : MonoBehaviour
{
    public GameObject mistake_collider;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initiating " + this.name);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("The mistake was made by stepping on " + this.name);
    }
}
