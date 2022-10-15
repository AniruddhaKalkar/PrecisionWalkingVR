using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour {
    Vector3 forward;
    Vector3 up;
    public GameObject cameraRig;
    public GameObject headset;

	// Use this for initialization
	void Start () {
        forward = cameraRig.transform.right * -1;
        up = cameraRig.transform.up;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ResetHead()
    {
        Quaternion rotation = Quaternion.LookRotation(forward, up);
        Quaternion newRotation = new Quaternion();
        newRotation.eulerAngles = new Vector3(cameraRig.transform.rotation.eulerAngles.x, cameraRig.transform.rotation.eulerAngles.y + (rotation.eulerAngles.y - headset.transform.rotation.eulerAngles.y), cameraRig.transform.rotation.eulerAngles.z);
        cameraRig.transform.rotation = newRotation;
    }
}
