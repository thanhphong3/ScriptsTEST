using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneryBarColor : MonoBehaviour
{
    // Start is called before the first frame update
    Slider SD;
    public int id;
    void Start()
    {
        SD = GetComponent<Slider>();
        transform.FindChild("Fill Area").transform.FindChild("Fill").GetComponent<Image>().color = new Color32(13, 38, 243, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (id == 1)
        {
            if (SD.value == SD.maxValue)
            {
                // 174,182,284,255
                transform.FindChild("Fill Area").transform.FindChild("Fill").GetComponent<Image>().color = new Color32(13, 38, 243, 255);
            }
            else
            {
                transform.FindChild("Fill Area").transform.FindChild("Fill").GetComponent<Image>().color = new Color32(174, 182, 248, 255);
            }
        }
        else
        {
            if (SD.value == SD.maxValue)
            {
                // 174,182,284,255
                transform.FindChild("Fill Area").transform.FindChild("Fill").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
            else
            {
                transform.FindChild("Fill Area").transform.FindChild("Fill").GetComponent<Image>().color = new Color32(238, 80, 80, 255);
            }
        }
    }
}
