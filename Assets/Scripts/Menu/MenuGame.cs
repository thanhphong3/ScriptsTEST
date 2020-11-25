using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGamee()
    {
        Application.Quit();
;    }

    public void StartGame()
    {
        ManThongSo.win1 = 0;
        ManThongSo.win2 = 0;
        ManThongSo.Match = 1;
        Application.LoadLevel("SampleScene");
    }
}
