using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    //public float speed;    
    private bool hasStarted = false;
    public GameObject tracker;
    public float speed = 1;

    void Start()
    {
        speed = PlayerPrefs.GetFloat("TreadmillInput")/2.23694f;
    }

    void Update()
    {
        if (hasStarted == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            hasStarted = true;
        }
    }  
    
    public void TaskOnClick()
    {
        hasStarted = true;
        
    }
    
    public void Pause()
    {
        hasStarted = false;
    }

    public void ResetFoot()
    {
        Vector3 p = tracker.transform.localPosition;
        transform.Translate(0, p[1], 0);
    }
}
