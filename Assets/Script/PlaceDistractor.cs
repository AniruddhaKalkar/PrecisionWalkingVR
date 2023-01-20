using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDistractor : MonoBehaviour
{

    public GameObject prefab;
    public GameObject target;
    public GameObject pathob;
    public GameObject dualtaskpanel;
    public int NumberOfObstacles;
    private int obheighttoggle = 1;
    private float obstacleheights;
    private int obwidth = 1;
    private float obwidthvar;
    private int obdepth = 1;
    private int obcolor = 1;
    private int obdynamicpred;
    private int obappearancepred = 1;
    private int obstyle = 1;
    private int oblight = 1;
    private int dualtask = 1;
    private int pathwidth;
    private float obheights;
    private float obheights_target;
    private float obwidthposition;
    private float obdepths;
    private float obdepths_target;
    private Color altColor = new Color(1f, 0f, 0f, 1);
    private Color altColor_target = new Color(1f, 1f, 1f, 1);
    private float grayscale;
    private GameObject lightObject;
    private Light myLight;
    private Color lightcolors;
    public Vector3 Obposition;
    public ArrayList ObOrder = new ArrayList();


    // Use this for initialization
    public void Place()
    {

        NumberOfObstacles = PlayerPrefs.GetInt("NumbOb");
        obheighttoggle = PlayerPrefs.GetInt("ObHeight");
        obstacleheights = PlayerPrefs.GetInt("ObHeightnum");
        obstacleheights = obstacleheights * 0.01f;
        obwidth = PlayerPrefs.GetInt("ObWidth");
        obwidthvar = PlayerPrefs.GetFloat("ObWidthVar");
        obdepth = PlayerPrefs.GetInt("ObDepth");
        obcolor = PlayerPrefs.GetInt("ObColor");
        obdynamicpred = PlayerPrefs.GetInt("ObDynamicPred");
        obappearancepred = PlayerPrefs.GetInt("ObAppearancePred");
        obstyle = PlayerPrefs.GetInt("ObStyle");
        oblight = PlayerPrefs.GetInt("Lighting");
        lightObject = GameObject.Find("Directional light");
        myLight = lightObject.GetComponent<Light>();
        pathwidth = PlayerPrefs.GetInt("Pathwidth");
        dualtask = PlayerPrefs.GetInt("DualTask");

        // get obstacle width
        if (obwidth == 1)
        {
            obwidthposition = (Random.Range(0.64f, 2.14f));
        }
        else if (obwidth == 2)
        {
            obwidthposition = (Random.Range(0.94f, 1.94f));
        }
        else if (obwidth == 3)
        {
            obwidthposition = 1.37f;
        }

        // get obstacle negotiation style
        obdepths = 0.1f;
        for (int i = 0; i < NumberOfObstacles; i++)
        {
            int randomIndex = 0;
            ObOrder.Add(randomIndex);
        }
        // get obstacle height
        obheights = (Random.Range(obstacleheights - 0.05f, obstacleheights + 0.05f));
        // get obstacle color
        altColor.r -= (Random.Range(0f, 1f));
        altColor.g -= (Random.Range(0f, 1f));
        altColor.b -= (Random.Range(0f, 1f));
        altColor = new Color(altColor.r, altColor.g, altColor.b, 1);

        // set position

        float position = (Random.Range(-10.0f, -5.1f)) - 10;
        float positiony = Random.Range(5.0f, 14.0f) / 10;
        float multiplier = Random.Range(0, 2) * 2 - 1;
        float positionz;
        if (multiplier > 0)
        {
            positionz = Random.Range(20.0f, 27.0f) / 10;
        }
        else
        {
            positionz = Random.Range(10.0f, 50.0f) / 100;
        }
        Vector3 Obposition = new Vector3(position, positiony, positionz);

        // instantiate obstacles
        GameObject go = Instantiate(prefab, Obposition, Quaternion.identity) as GameObject;

        go.GetComponent<MoveObstacle>().startpos = Obposition;

        // change color
        MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
        newMaterial.color = altColor;
        gameObjectRenderer.material = newMaterial;

        // change scale
        Vector3 scale = go.transform.localScale;
        scale.Set(obdepths, obheights, obwidthvar);
        go.transform.localScale = scale;

        // put it under the parent object
        go.transform.parent = GameObject.Find("Objects").transform;
        go.GetComponent<MoveObstacle>().parentpos = go.transform.parent.position;


        // place path obstacle
        for (int i = 1; i < 30 + 1; i++)
        {
            float path_positionx = (Random.Range(-40.0f, -30.1f)) - 15 * i;
            Vector3 pathposition1 = new Vector3(path_positionx, 20f, 5f);
            Vector3 pathposition2 = new Vector3(path_positionx, 20f, 6f);
            GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
            GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
            path1.transform.parent = GameObject.Find("Objects").transform;
            path2.transform.parent = GameObject.Find("Objects").transform;

        }

        // get lighting position
        lightcolors.r = 255 / 255f;
        lightcolors.g = 195 / 255f;
        lightcolors.b = 195 / 255f;
        lightcolors = new Color(lightcolors.r, lightcolors.g, lightcolors.b, 0.29f);
        myLight.color = lightcolors;
        Vector3 rotat = new Vector3(-8.328f, -459.50f, -454.94f);
        myLight.transform.Rotate(rotat);
        dualtaskpanel.gameObject.SetActive(false);

    }
}

