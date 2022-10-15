using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour {

    Vector3 forward;
    Vector3 up;
    public GameObject cameraRig;
    public GameObject headset;
    Button yourButton;

    // Use this for initialization
    void Start()
    {
        forward = cameraRig.transform.right * -1;
        up = cameraRig.transform.up;

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        
            Quaternion rotation = Quaternion.LookRotation(forward, up);
            Debug.Log("Rotation: " + rotation.eulerAngles.y);
            Quaternion newRotation = new Quaternion();
            newRotation.eulerAngles = new Vector3(cameraRig.transform.rotation.eulerAngles.x, cameraRig.transform.rotation.eulerAngles.y + (rotation.eulerAngles.y - headset.transform.rotation.eulerAngles.y), cameraRig.transform.rotation.eulerAngles.z);
            cameraRig.transform.rotation = newRotation;
            Debug.Log("Clicked");
        
    }
}



    
