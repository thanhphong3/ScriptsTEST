using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManThongSo : MonoBehaviour
{
    // Start is called before the first frame update
    public static int win1 = 0, win2 = 0;
    public static int Match = 1;
    public GameObject A1, D1, A2, D2;
    public Text T1, T2,Point1,Point2,MatchText;
    public GameObject TileMap1, TileMap2,NumberMatch, WhoWin;
    public GameObject Ball;

    void Start()
    {

        try
        {
            if (Match % 2 != 0)
            {
                Vector3 tmm = new Vector3(Random.Range(-7f, 7f), 0.6f, Random.Range(-11f, 0f));
                Instantiate(Ball, tmm, Quaternion.identity);
            }
            else
            {
                Vector3 tmm = new Vector3(Random.Range(-7f, 7f), 0.6f, Random.Range(0f, 11f));
                Instantiate(Ball, tmm, Quaternion.identity);
            }
        }
        catch { };
      


    }

    // Update is called once per frame
    void Update()
    {
        
        RunMan();
        Point1.text = win1.ToString();
        Point2.text = win2.ToString();
        MatchText.text = "Match : "+ Match;
    }
    
    void RunMan()
    {//Penalty
        if (Match >= 6)
        {
            NumberMatch.GetComponent<Text>().text = "MATCH PENALTY " + Match;
            NumberMatch.SetActive(true);
           
                if(Match==6)
                TileMap1.GetComponent<Text>().text = "Player1 Play";
                else
                    TileMap1.GetComponent<Text>().text = "Player2 Play";

                TileMap1.SetActive(true);




            }
        else
        {
            NumberMatch.GetComponent<Text>().text = "MATCH " + Match;
            NumberMatch.SetActive(true);
            if (Match % 2 != 0)
            {
                A1.SetActive(true);
                A2.SetActive(false);
                D1.SetActive(false);
                D2.SetActive(true);

                T1.text = "Player1(Attacker)";
                T2.text = "Player2 (Defender)";

                TileMap1.SetActive(true);
            }
            else
            {
                A1.SetActive(false);
                A2.SetActive(true);
                D1.SetActive(true);
                D2.SetActive(false);

                T1.text = "Player1(Defender)";
                T2.text = "Player2 (Attacker)";

                TileMap2.SetActive(true);
            }
        }
    }

    void RandomBall()
    {

      
    }
}
