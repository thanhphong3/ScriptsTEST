using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PanelPause;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  Pausee()
    {
        

            StartCoroutine(waitPause());
        

    }
    IEnumerator waitPause ()
    {
        PanelPause.SetActive(true);
        ThongSo.IsSpaw = false;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;

    }
    public void QuitGamee()
    {
        Application.Quit();
        
    }
    public void Continouee()
    {
        Time.timeScale = 1;
        PanelPause.SetActive(false);
        ThongSo.IsSpaw = true;
    }
    public void GoHome()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }
}
