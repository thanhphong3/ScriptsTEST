using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ball;
    public GameObject p1, p2;
    public GameObject Point1,Point2;
    public int match;
    void Start()
    {
       // ManThongSo.Match = match;
        SpawBall();
        SpawPlayer();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawBall()
    {
        Vector3 tmm = new Vector3(Random.Range(-7f, 7f), 0.6f, Random.Range(-12f, 12f));
        Instantiate(Ball, tmm, Quaternion.identity);
    }
    void SpawPlayer()
    {
        if(ManThongSo.Match==6)
        {
            GameObject P = Instantiate(p1, Point1.transform.position, Quaternion.identity);
           // P.GetComponent<PlayerPen>().Gon = "Gon2";
            Point2.SetActive(false);

        }

        if (ManThongSo.Match == 7)
        {
            GameObject P = Instantiate(p2, Point2.transform.position, Quaternion.identity);
            //P.GetComponent<PlayerPen>().Gon = "Gon1";
            P.transform.rotation = Quaternion.Euler(0, 180, 0);
            Point1.SetActive(false);

        }
    }
}
