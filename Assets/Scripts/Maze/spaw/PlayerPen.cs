using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPen : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Animator anim;
    float speed = 1.5f;
     Transform CurrentPoint;
    GameObject Ball;

    public string Gon;

    public bool IsCham=false;

    public static bool Comp1=false,Comp2=false;
    public static int time1 = 0, time2 = 0;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        goc(transform.position, Run());
        Move();
       
    }

   

    void goc(Vector3 here, Vector3 tt)
    {

        Vector3 mousePos = tt;


        // Vector3 here = transform.position;
        Vector3 lookDir = mousePos - here;


        float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
    void Move()
    {
        if(ThongSo.Timecurrent<=15)
        {
            rb.velocity = transform.forward * (speed+1f);
        }
        else
        rb.velocity = transform.forward * speed;
        anim.SetBool("run", true);
    }


    Vector3 Run()
    {
        Vector3 kq = transform.position;
       

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                kq = hit.point;
            }
        
        return kq;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="ball")
        {
            
            Ball.transform.SetParent(transform);
            Ball.transform.position= transform.FindChild("PointBall").transform.position;
            IsCham = true;
        }

        if(other.tag=="Gon2" && IsCham==true && gameObject.tag=="player1")
        {
            
            StartCoroutine(Win());
        }
        if (other.tag == "Gon1" && IsCham == true && gameObject.tag == "player2")
        {
           
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        GameObject.Find("Canvas").transform.FindChild("Pause").gameObject.SetActive(false);
        GameObject.Find("Music").transform.FindChild("end").gameObject.SetActive(true);
        GameObject.Find("Music").transform.FindChild("goal").gameObject.SetActive(true);

        Camera.main.GetComponent<Animator>().Play("Camera");

        GameObject.Find("Canvas").transform.FindChild("WhoWin").gameObject.SetActive(true);
        if (gameObject.tag == "player1")
        {
            ManThongSo.win1++;
            GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER 1 WIN "+"Time : "+ThongSo.Timecurrent+"s";
            Comp1 = true;
            time1 = ThongSo.Timecurrent;
        }
        
        if (gameObject.tag == "player2")
        {
            ManThongSo.win2++;
            GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER 2 WIN " + "Time : " + ThongSo.Timecurrent+"s";
            Comp2 = true;
            time2 = ThongSo.Timecurrent;

        }
        anim.Play("win");
        this.enabled = false;
        yield return new WaitForSeconds(5);
        ManThongSo.Match++;
        if(ManThongSo.Match==8)
        {
            Application.LoadLevel("Win");
        }
        else
        Application.LoadLevel("Pen");

    }

}
