using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThongSo : MonoBehaviour
{
    // Start is called before the first frame update
    public int TimeLimit;
    public static int Timecurrent;
    public static bool IsSpaw;
    public Text timet;
    public static bool Isrun=true;
    public GameObject Speed;

    void Start()
    {
        IsSpaw = true;
     
        Timecurrent = TimeLimit;
        timet.text = TimeLimit.ToString()+"s";
        Isrun = true;

        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator wait()
    {
        if (Isrun)
        {
            
                if (Timecurrent == 15)
                {
                    timet.GetComponent<Text>().color = Color.red;
                    Speed.SetActive(true);
                }

                if (Timecurrent > 0)
                {
                    Timecurrent -= 1;
                    timet.text = Timecurrent.ToString() + "s";
                }
                else if (Timecurrent == 0)
                {
                    StartCoroutine(Raw());
                    Timecurrent = -1;
                }
                else
                {

                }

           
        }
            yield return new WaitForSeconds(1);

        
        StartCoroutine(wait());

    }

    IEnumerator Raw()
    {
        GameObject.Find("Music").transform.FindChild("end").gameObject.SetActive(true);

        Camera.main.GetComponent<Animator>().Play("Camera");
        GameObject.Find("Canvas").transform.FindChild("Pause").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("WhoWin").gameObject.SetActive(true);

        if (gameObject.tag == "ManPen")
        {
            if (ManThongSo.Match == 6)
            {
                GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER1 NOT COMPLETE";
                GameObject.FindGameObjectWithTag("player1").GetComponent<Animator>().Play("defeat");
                GameObject.FindGameObjectWithTag("player1").GetComponent<PlayerPen>().enabled = false;
            }
            else
            {
                GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER2 NOT COMPLETE";

                GameObject.FindGameObjectWithTag("player2").GetComponent<Animator>().Play("defeat");
                GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerPen>().enabled = false;
            }

            yield return new WaitForSeconds(5);
            ManThongSo.Match++;
            if (ManThongSo.Match == 8)
            {
                Application.LoadLevel("Win");
            }
            else
                Application.LoadLevel("Pen");
        }
        else
        {
            GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER1 RAW PLAYER2";

            ThongSo.IsSpaw = false;

            GameObject[] listdd = GameObject.FindGameObjectsWithTag("player1");
            GameObject[] listdt = GameObject.FindGameObjectsWithTag("player2");

            foreach (GameObject i in listdd)
            {
                Rawcon(i);
            }
            foreach (GameObject i in listdt)
            {
                Rawcon(i);
            }
            yield return new WaitForSeconds(5);
            ManThongSo.Match++;
            if (ManThongSo.Match >= 6  )
            {
                if(ManThongSo.win1 == ManThongSo.win2)
                {
                    Application.LoadLevel("Pen");
                }
                else
                {
                    Application.LoadLevel("Win");
                }
            }
               
            else
                Application.LoadLevel("SampleScene");
        }

       

       
      
    }

    void Rawcon(GameObject i)
    {
        try
        {
        i.GetComponent<Animator>().Play("win");
        i.transform.FindChild("vongvang").gameObject.SetActive(false);
        i.transform.FindChild("muiten").gameObject.SetActive(false);
        i.transform.FindChild("Range").gameObject.SetActive(false);
        i.transform.FindChild("SetPefabs").gameObject.SetActive(false);
        i.GetComponent<Rigidbody>().velocity = Vector3.zero;    


            i.GetComponent<SolidDef>().enabled = false;
            i.GetComponent<Solid>().enabled = false;
            i.GetComponent<SolidDef>().TT = 0;
            i.GetComponent<Solid>().TT = 0;
        }
        catch { }
    }
}
