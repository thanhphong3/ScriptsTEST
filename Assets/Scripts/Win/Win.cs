using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1,player2;
    public Transform  PointWin;
    public Text NameWin;

    public GameObject Panel1, Panel2;
    public Text t1, t2, t3, t4;
    void Start()
    {
        KT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void KT ()
    {
        if(ManThongSo.Match==6)
        {
            Panel1.SetActive(true);
            t1.text = ManThongSo.win1.ToString();
            t2.text = ManThongSo.win2.ToString();
            if(ManThongSo.win1>ManThongSo.win2)
            {
                WhoWin(player1);
                NameWin.text="Player1 Winner";
            }
            else
            {
                WhoWin(player2);
                NameWin.text = "Player2 Winner";
            }
        }
        else
        {
            Panel2.SetActive(true);
         
            if (PlayerPen.Comp1==true && PlayerPen.Comp2==true)
            {
                t3.text = PlayerPen.time1.ToString();
                t4.text = PlayerPen.time2.ToString();
                if (PlayerPen.time1>PlayerPen.time2)
                {
                    WhoWin(player1);
                    NameWin.text = "Player1 Winner";
                }
                else
                {
                    WhoWin(player2);
                    NameWin.text = "Player2 Winner";
                }
            }
            else if(PlayerPen.Comp1 == false && PlayerPen.Comp2 == false)
            {
                t3.text = "Not Complete";
                t4.text = "Not Complete";
                
                    WhoWin(player1);
                WhoWin(player2);
                NameWin.fontSize = 80;
                NameWin.text = "Player1 Raw Player2 ";
               
                  
                    
                
            }
            else
            {
                if (PlayerPen.Comp1 == true)
                {
                    t3.text = PlayerPen.time1.ToString();
                    t4.text = "Not Complete";

                    WhoWin(player1);
                    NameWin.text = "Player1 Winner";
                }
                else
                {
                    t3.text = "Not Complete";
                    t4.text = PlayerPen.time2.ToString();
                    WhoWin(player2);
                    NameWin.text = "Player2 Winner";
                }
            }
        }
    }

    void WhoWin(GameObject p)
    {
        GameObject P = Instantiate(p, PointWin.position, Quaternion.identity);
        P.transform.rotation = Quaternion.Euler(0, 180, 0);
        P.GetComponent<Animator>().Play("win");
    }
    public void Home()
    {

        Application.LoadLevel("Menu");
    }
}
