using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{

    // toggle game objects
    
    public Toggle Heightlevel1;
    public Toggle Heightlevel2;
    public Toggle Heightlevel3;
    public Toggle Widthlevel1;
    public Toggle Widthlevel2;
    public Toggle Widthlevel3;
    public Toggle Depthlevel1;
    public Toggle Depthlevel2;
    public Toggle Depthlevel3;
    public Toggle Colorlevel1;
    public Toggle Colorlevel2;
    public Toggle Colorlevel3;
    public Toggle Pathwidthlevel1;
    public Toggle Pathwidthlevel2;
    public Toggle Pathwidthlevel3;
    public Toggle DyPredlevel1;
    public Toggle DyPredlevel2;
    public Toggle DyPredlevel3;
    public Toggle ApPredlevel1;
    public Toggle ApPredlevel2;
    public Toggle ApPredlevel3;
    public Toggle Stylelevel1;
    public Toggle Stylelevel2;
    public Toggle Stylelevel3;
    public Toggle Lightinglevel1;
    public Toggle Lightinglevel2;
    public Toggle Lightinglevel3;
    public Toggle Duallevel1;
    public Toggle Duallevel2;
    public Toggle Duallevel3;
    private GameObject obstacles;
    public InputField speed;
    public static float treadmillspeed;
    public InputField numbOb;
    public static int numbObInput;
    public Slider Heightval;
    public static int Heightvalint;
    public ArrayList heightArray = new ArrayList();
    public ArrayList widthposArray = new ArrayList();
    //private GameObject go;
    public GameObject settingpanel;
    public GameObject gamepanel;

    void Start()
    {
        gamepanel.gameObject.SetActive(false);
    }

    public void Setspeed()
    {
        treadmillspeed = float.Parse(speed.text);
        PlayerPrefs.SetFloat("TreadmillInput", treadmillspeed);
    }

    public void SetNumber()
    {
        numbObInput = int.Parse(numbOb.text);
        PlayerPrefs.SetInt("NumbOb", numbObInput);
    }
    public void SetHeight()
    {
        Heightvalint = (int)Heightval.value;
    }

    public void ActiveToggle()
    {
        
        // height toggle
        if (Heightlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObHeight", 1);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);
        }
        else if (Heightlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObHeight", 2);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);
        }
        else if (Heightlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObHeight", 3);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);
        }

        // width toggle
        if (Widthlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObWidth", 1);
            PlayerPrefs.SetFloat("ObWidthVar", 0.8f);
        }
        else if (Widthlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObWidth", 2);
            PlayerPrefs.SetFloat("ObWidthVar", 1.5f);
        }

        else if (Widthlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObWidth", 3);
            PlayerPrefs.SetFloat("ObWidthVar", 3f);
        }

        // shape toggle
        if (Depthlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObDepth", 1);
        }
        else if (Depthlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObDepth", 2);            
        }
        else if (Depthlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObDepth", 3);            
        }

        // color toggle
        if (Colorlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObColor", 1);
        }
        else if (Colorlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObColor", 2);
        }
        else if (Colorlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObColor", 3);
        }

        // path width toggle
        if (Pathwidthlevel1.isOn)
        {
            PlayerPrefs.SetInt("Pathwidth", 1);
        }
        else if (Pathwidthlevel2.isOn)
        {
            PlayerPrefs.SetInt("Pathwidth", 2);
        }
        else if (Pathwidthlevel3.isOn)
        {
            PlayerPrefs.SetInt("Pathwidth", 3);
        }

        // dynamic predictability toggle
        if (DyPredlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObDynamicPred", 1);
        }
        else if (DyPredlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObDynamicPred", 2);
        }
        else if (DyPredlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObDynamicPred", 3);
        }

        // appearance predictability toggle
        if (ApPredlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObAppearancePred", 1);
        }
        else if (ApPredlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObAppearancePred", 2);
        }
        else if (ApPredlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObAppearancePred", 3);
        }

        // negotiation style toggle
        if (Stylelevel1.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 1);
        }
        else if (Stylelevel2.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 2);
        }
        else if (Stylelevel3.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 3);
        }

        // lighting toggle
        if (Lightinglevel1.isOn)
        {
            PlayerPrefs.SetInt("Lighting", 1);
        }
        else if (Lightinglevel2.isOn)
        {
            PlayerPrefs.SetInt("Lighting", 2);
        }
        else if (Lightinglevel3.isOn)
        {
            PlayerPrefs.SetInt("Lighting", 3);
        }

        // dual task toggle
        if (Duallevel1.isOn)
        {
            PlayerPrefs.SetInt("DualTask", 1);
        }
        else if (Duallevel2.isOn)
        {
            PlayerPrefs.SetInt("DualTask", 2);
        }
        else if (Duallevel3.isOn)
        {
            PlayerPrefs.SetInt("DualTask", 3);
        }
    }   

    public void Easy()
    {
        treadmillspeed = float.Parse(speed.text);
        numbObInput = int.Parse(numbOb.text);
        PlayerPrefs.SetFloat("TreadmillInput", treadmillspeed);
        PlayerPrefs.SetInt("NumbOb", numbObInput);
        PlayerPrefs.SetFloat("ObWidthVar", 0.8f);
        PlayerPrefs.SetInt("ObWidth", 1);

        // negotiation style toggle
        if (Stylelevel1.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 1);            
            Heightvalint = 12;
            PlayerPrefs.SetInt("ObHeight", 1);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);                        
            PlayerPrefs.SetInt("ObColor", 1);
            PlayerPrefs.SetInt("Pathwidth", 1);
            PlayerPrefs.SetInt("ObDynamicPred", 1);
            PlayerPrefs.SetInt("ObAppearancePred", 1);
            PlayerPrefs.SetInt("Lighting", 1);
            PlayerPrefs.SetInt("DualTask", 1);
        }
        else if (Stylelevel2.isOn)
        {            
            PlayerPrefs.SetInt("ObStyle", 2);
            PlayerPrefs.SetInt("ObColor", 1);
            PlayerPrefs.SetInt("Pathwidth", 1);
            PlayerPrefs.SetInt("ObDynamicPred", 1);
            PlayerPrefs.SetInt("ObAppearancePred", 1);
            PlayerPrefs.SetInt("Lighting", 1);
            PlayerPrefs.SetInt("DualTask", 1);
            PlayerPrefs.SetInt("ObDepth", 1);
        }
        else if (Stylelevel3.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 3);
            Heightvalint = 12;
            PlayerPrefs.SetInt("Pathwidth", 1);
            PlayerPrefs.SetInt("ObHeight", 1);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);            
            PlayerPrefs.SetInt("ObDynamicPred", 1);
            PlayerPrefs.SetInt("ObAppearancePred", 1);
            PlayerPrefs.SetInt("Lighting", 1);
            PlayerPrefs.SetInt("DualTask", 1);
            PlayerPrefs.SetInt("ObDepth", 1);
        }

        settingpanel.gameObject.SetActive(false);
        gamepanel.gameObject.SetActive(true);
    }

    public void Medium()
    {
        treadmillspeed = float.Parse(speed.text);
        numbObInput = int.Parse(numbOb.text);
        PlayerPrefs.SetFloat("TreadmillInput", treadmillspeed);
        PlayerPrefs.SetInt("NumbOb", numbObInput);
        PlayerPrefs.SetFloat("ObWidthVar", 1.5f);
        PlayerPrefs.SetInt("ObWidth", 1);

        // negotiation style toggle
        if (Stylelevel1.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 1);            
            Heightvalint = 12;
            PlayerPrefs.SetInt("ObHeight", 2);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);
            PlayerPrefs.SetInt("ObColor", 3);
            PlayerPrefs.SetInt("ObDynamicPred", 2);
            PlayerPrefs.SetInt("ObAppearancePred", 1);
            PlayerPrefs.SetInt("Lighting", 1);
            PlayerPrefs.SetInt("DualTask", 2);
            PlayerPrefs.SetInt("Pathwidth", 2);

        }
        else if (Stylelevel2.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 2);
            PlayerPrefs.SetInt("ObColor", 3);
            PlayerPrefs.SetInt("ObDynamicPred", 2);
            PlayerPrefs.SetInt("ObAppearancePred", 1);
            PlayerPrefs.SetInt("Lighting", 1);
            PlayerPrefs.SetInt("DualTask", 2);
            PlayerPrefs.SetInt("ObDepth", 2);
            PlayerPrefs.SetInt("Pathwidth", 2);
        }
        else if (Stylelevel3.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 3);
            Heightvalint = 12;
            PlayerPrefs.SetInt("ObHeight", 2);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);            
            PlayerPrefs.SetInt("ObDynamicPred", 2);
            PlayerPrefs.SetInt("ObAppearancePred", 1);
            PlayerPrefs.SetInt("Lighting", 1);
            PlayerPrefs.SetInt("DualTask", 2);
            PlayerPrefs.SetInt("ObDepth", 2);
            PlayerPrefs.SetInt("Pathwidth", 2);
        }

        settingpanel.gameObject.SetActive(false);
        gamepanel.gameObject.SetActive(true);
    }

    public void Hard()
    {
        treadmillspeed = float.Parse(speed.text);
        numbObInput = int.Parse(numbOb.text);
        PlayerPrefs.SetFloat("TreadmillInput", treadmillspeed);
        PlayerPrefs.SetInt("NumbOb", numbObInput);
        PlayerPrefs.SetFloat("ObWidthVar", 1.5f);
        PlayerPrefs.SetInt("ObWidth", 1);

        // negotiation style toggle
        if (Stylelevel1.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 1);
            Heightvalint = 18;
            PlayerPrefs.SetInt("ObHeight", 3);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);
            PlayerPrefs.SetInt("ObColor", 3);
            PlayerPrefs.SetInt("ObDynamicPred", 1);
            PlayerPrefs.SetInt("ObAppearancePred", 3);
            PlayerPrefs.SetInt("Lighting", 2);
            PlayerPrefs.SetInt("DualTask", 3);
            PlayerPrefs.SetInt("Pathwidth", 3);
        }
        else if (Stylelevel2.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 2);
            PlayerPrefs.SetInt("ObColor", 3);
            PlayerPrefs.SetInt("ObDynamicPred", 1);
            PlayerPrefs.SetInt("ObAppearancePred", 3);
            PlayerPrefs.SetInt("Lighting", 2);
            PlayerPrefs.SetInt("DualTask", 3);
            PlayerPrefs.SetInt("ObDepth", 3);
            PlayerPrefs.SetInt("Pathwidth", 3);
        }
        else if (Stylelevel3.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 3);
            Heightvalint = 18;
            PlayerPrefs.SetInt("ObHeight", 3);
            PlayerPrefs.SetInt("ObHeightnum", Heightvalint);
            PlayerPrefs.SetInt("ObColor", 3);
            PlayerPrefs.SetInt("ObDynamicPred", 1);
            PlayerPrefs.SetInt("ObAppearancePred", 3);
            PlayerPrefs.SetInt("Lighting", 2);
            PlayerPrefs.SetInt("DualTask", 3);
            PlayerPrefs.SetInt("ObDepth", 3);
            PlayerPrefs.SetInt("Pathwidth", 3);
        }

        settingpanel.gameObject.SetActive(false);
        gamepanel.gameObject.SetActive(true);
    }

    public void OnSubmit()
    {
        Setspeed();
        SetNumber();
        SetHeight();
        ActiveToggle();      
        settingpanel.gameObject.SetActive(false);
        gamepanel.gameObject.SetActive(true);        
    }


}