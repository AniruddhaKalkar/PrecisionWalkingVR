using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomplace : MonoBehaviour
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
    public void PlaceObstacle()
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
        if (obstyle == 1)
        {
            obdepths = 0.1f;
            for (int i = 0; i < NumberOfObstacles; i++)
            {
                int randomIndex = 0;
                ObOrder.Add(randomIndex);
            }

            // get obstacle height
            if (obheighttoggle == 1)
            {
                obheights = obstacleheights;
            }
            else if (obheighttoggle == 2)
            {
                obheights = (Random.Range(obstacleheights - 0.03f, obstacleheights + 0.03f));
            }
            else if (obheighttoggle == 3)
            {
                obheights = (Random.Range(obstacleheights - 0.05f, obstacleheights + 0.05f));
            }

            // get obstacle color
            if (obcolor == 1)
            {
                altColor = altColor;

            }
            else if (obcolor == 2)
            {
                grayscale = Random.Range(0f, 1f);
                altColor.r -= grayscale;
                altColor.g -= grayscale;
                altColor.b -= grayscale;
                altColor = new Color(altColor.r, altColor.g, altColor.b, 1);
            }
            else if (obcolor == 3)
            {
                altColor.r -= (Random.Range(0f, 1f));
                altColor.g -= (Random.Range(0f, 1f));
                altColor.b -= (Random.Range(0f, 1f));
                altColor = new Color(altColor.r, altColor.g, altColor.b, 1);
            }

            // set position
            float position = (Random.Range(-10.0f, -5.1f)) - 10;
            Vector3 Obposition = new Vector3(position, obheights / 2f, obwidthposition);

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
        }

        else if (obstyle == 2)
        {
            obheights = 0.01f;
            altColor_target = altColor_target;
            for (int i = 0; i < NumberOfObstacles; i++)
            {
                int randomIndex = 1;
                ObOrder.Add(randomIndex);
            }

            // get obstacle depth
            if (obdepth == 1)
            {
                obdepths_target = 0.5f;
            }
            else if (obdepth == 2)
            {
                obdepths_target = 0.3f;
            }
            else if (obdepth == 3)
            {
                obdepths_target = 0.1f;
            }

            // set position
            float position = (Random.Range(-10.0f, -5.1f)) - 10;
            Vector3 Obposition = new Vector3(position, 0.02f / 2, obwidthposition);

            // instantiate obstacles
            GameObject go = Instantiate(target, Obposition, Quaternion.identity) as GameObject;
            go.GetComponent<MoveObstacle>().startpos = Obposition;

            // change color
            MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer>();
            Material newMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
            newMaterial.color = altColor;
            gameObjectRenderer.material = newMaterial;

            // change scale
            Vector3 scale = go.transform.localScale;
            scale.Set(obdepths_target, 0.02f, obwidthvar);
            go.transform.localScale = scale;

            // put it under the parent object
            go.transform.parent = GameObject.Find("Objects").transform;
            go.GetComponent<MoveObstacle>().parentpos = go.transform.parent.position;
        }

        else if (obstyle == 3)
        {
            for (int i = 1; i < NumberOfObstacles; i++)
            {
                int randomIndex = Random.Range(0, 2);
                ObOrder.Add(randomIndex);
            }

            obheights_target = 0.01f;
            obdepths = 0.1f;
            altColor = new Color(1f, 0f, 0f, 1);
            altColor_target = altColor_target;

            // get obstacle height
            if (obheighttoggle == 1)
            {
                obheights = obstacleheights;
            }
            else if (obheighttoggle == 2)
            {
                obheights = (Random.Range(obstacleheights - 0.03f, obstacleheights + 0.03f));
            }
            else if (obheighttoggle == 3)
            {
                obheights = (Random.Range(obstacleheights - 0.05f, obstacleheights + 0.05f));
            }

            // get obstacle depth
            if (obdepth == 1)
            {
                obdepths_target = 0.5f;
            }
            else if (obdepth == 2)
            {
                obdepths_target = 0.3f;
            }
            else if (obdepth == 3)
            {
                obdepths_target = 0.1f;
            }

            // set position
            float position = (Random.Range(-10.0f, -5.1f)) - 10;
            Vector3 Obposition = new Vector3(position, obheights / 2f, obwidthposition);

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
        }

        // place path obstacle
        Debug.Log(pathwidth);
        if (pathwidth == 2)
        {
            for (int i = 1; i < 30 + 1; i++)
            {
                float path_positionx = (Random.Range(-10.0f, -5.1f)) - 15 * i;
                Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.5f);
                Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.3f);
                GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                path1.transform.parent = GameObject.Find("Objects").transform;
                path2.transform.parent = GameObject.Find("Objects").transform;
            }
        }
        else if (pathwidth == 3)
        {
            for (int i = 1; i < 30 + 1; i++)
            {
                float path_positionx = (Random.Range(-10.0f, -5.1f)) - 15 * i;
                Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.1f);
                Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.6f);
                GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                path1.transform.parent = GameObject.Find("Objects").transform;
                path2.transform.parent = GameObject.Find("Objects").transform;
            }
        }
        else
        {
            for (int i = 1; i < 30 + 1; i++)
            {
                float path_positionx = (Random.Range(-40.0f, -30.1f)) - 15 * i;
                Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.5f);
                Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.3f);
                GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                path1.transform.parent = GameObject.Find("Objects").transform;
                path2.transform.parent = GameObject.Find("Objects").transform;
                Debug.Log(path_positionx);
                Debug.Log(pathposition1);
                Debug.Log(pathposition2);
            }
        }



        // get lighting position
        if (oblight == 1)
        {
            lightcolors.r = 1f;
            lightcolors.g = 1f;
            lightcolors.b = 1f;
            lightcolors = new Color(lightcolors.r, lightcolors.g, lightcolors.b, 1);
            myLight.color = lightcolors;
        }

        else if (oblight == 2)
        {
            lightcolors.r = 255 / 255f;
            lightcolors.g = 195 / 255f;
            lightcolors.b = 195 / 255f;
            lightcolors = new Color(lightcolors.r, lightcolors.g, lightcolors.b, 0.5f);
            myLight.color = lightcolors;
            Vector3 rotat = new Vector3(90f, 100f, 50f);
            myLight.transform.Rotate(rotat);
        }

        else if (oblight == 3)
        {
            lightcolors.r = 255 / 255f;
            lightcolors.g = 195 / 255f;
            lightcolors.b = 195 / 255f;
            lightcolors = new Color(lightcolors.r, lightcolors.g, lightcolors.b, 0.29f);
            myLight.color = lightcolors;
            Vector3 rotat = new Vector3(-8.328f, -459.50f, -454.94f);
            myLight.transform.Rotate(rotat);
        }

        // dual task
        if (dualtask == 1 || dualtask == 3)
        {
            dualtaskpanel.gameObject.SetActive(false);
        }

        else
        {
            dualtaskpanel.gameObject.SetActive(true);
        }
    }
}

