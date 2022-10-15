using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateWords : MonoBehaviour
{

    public TextAsset textFile;
    string[] ListofWords;    
    List<string> Task = new List<string>();
    private ArrayList order = new ArrayList();
    private ArrayList ObOrder = new ArrayList();
    private GUIStyle guiStyle = new GUIStyle();

    // Use this for initialization
    void Start()
    {
        if (textFile != null)
        {
            ListofWords = (textFile.text.Split('\n'));

            for (int i = 0; i < 5; i++)
            {
                int randomIndex = Random.Range(0, 20);                
                if (order.Contains(randomIndex))
                {
                    randomIndex = Random.Range(0, 20);
                }
                order.Add(randomIndex);
            }

            for (int i = 0; i < 5; i++)
            {
                int listorder = (int)order[i];
                string dialog = ListofWords[listorder];
                Task.Add(dialog);
            }
        }
    }

    public void OnGUI()
    {
        for (int i = 0; i < Task.Count; i++)
        {
            GUI.contentColor = Color.black;
            guiStyle.fontSize = 20;
            GUI.Label(new Rect(47, 617+(i*28), 100, 100), Task[i], "color");
        }
    }
}
