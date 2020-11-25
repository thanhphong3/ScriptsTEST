using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Solid : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Sl = 0;
    public int id;
    public static bool TTBall  =false;
    public string DongDoi = "player1";
    public string DoiThu = "player2";

    public string GonDich;

    public int TT = 0;
    Animator anim;
    GameObject Ball;
    public float NhatBallSpeed = 1.5f;
     Transform PointBall;
    public Transform PointGon;
     Transform PointKick;
    Rigidbody rb;

    public int Chieu = 1;

    GameObject Set;

    public GameObject ef;

    public Material Gray;
     Material TmMaterial;

    void Start()
    {
        Sl++;
        id = Sl;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Set = transform.FindChild("SetPefabs").gameObject;
        Set.active = false;

       PointBall = transform.FindChild("PointBall").transform; 
        PointKick = transform.FindChild("PointKick").transform;

        StartCoroutine(wait0());
        Ball = GameObject.FindGameObjectWithTag("ball");

        TmMaterial = transform.FindChild("Beta_Surface").gameObject.GetComponent<SkinnedMeshRenderer>().material ;
    }

    // Update is called once per frame
    void Update()
    {
        if(ThongSo.Timecurrent<=0)
        {

        }
        else
        {
            RunTT();
            KtChamBall();
        }
   
    }

    void RunTT()
    {
        if (TT == 0)
        {
            anim.SetBool("run", false); transform.FindChild("vongvang").gameObject.SetActive(false);
            transform.FindChild("Run").gameObject.SetActive(false);
        }
        
        if (TT == 1)
        {
            goc(transform.position, Ball.transform);
            Move(Ball.transform,1.5f);
            transform.FindChild("Run").gameObject.SetActive(true);
        }
        if (TT == 2)
        {
            transform.FindChild("Run").gameObject.SetActive(true);
            anim.SetBool("run", true);

            if (Chieu == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = transform.forward * 1.5f ;
            }
            else
            {
               // transform.rotation = Quaternion.Euler(0, 180, 0);
                rb.velocity = new Vector3(0,0,-1) * 1.5f ;
            }


           
        }
        if (TT == 3)
        {
            transform.FindChild("Run").gameObject.SetActive(true);
            goc(transform.position, PointGon);

            if (ThongSo.Timecurrent <= 15)
            {
                Move(PointGon, 1.5f);
                Debug.Log("tang toc");
            }
            else Move(PointGon, 0.75f);

            transform.FindChild("vongvang").gameObject.SetActive(true);
        }

        if (TT == 4)
        {
            transform.FindChild("Run").gameObject.SetActive(false);
            anim.SetBool("run", false);
            goc(transform.position, Ball.transform);
        }
        if (TT == 5)   // trang thai lose
        {
            rb.velocity = Vector3.zero;
            transform.FindChild("Run").gameObject.SetActive(false);

        }

     
    }


    IEnumerator wait0()
    {
        TT = 0;
        yield return new WaitForSeconds(0.5f);

        if (id == 1)
        {
            TT = 1;
            anim.SetBool("run", true);
        }
        else
        {
            TT = 2;
        }

    }

    void goc(Vector3 here,Transform tt)
    {

        Vector3 mousePos = tt.position;


       // Vector3 here = transform.position;
        Vector3 lookDir = mousePos - here;


        float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    void KtChamBall()
    {
        if(Ball.transform.position==transform.position)
        {
          
            anim.SetBool("run", true);
           

            if(TT==4) { SolidDef.Lock = false; }

            TTBall = false;
            Destroy(Ball.GetComponent<Rigidbody>());
            Ball.transform.SetParent(transform);
            Ball.transform.position = PointBall.position;
            Ball.GetComponent<BallRotation>().enabled = true;
            TT = 3;
        }
    }
    void Move(Transform tt,float speed )
        {
        
             Vector3 newPos= Vector3.MoveTowards(transform.position, tt.position, speed* Time.deltaTime);

             rb.MovePosition(newPos);
      
    }



    void Nearnest()
    {
        GameObject[] listp = GameObject.FindGameObjectsWithTag(DongDoi);
        float min = 100f;
        GameObject tmm=null;

        foreach (GameObject i in listp)
        {
            if(i.GetComponent<Solid>().id!=id )
            {
                if(Vector3.Distance(i.transform.position,transform.position)<min && i.GetComponent<Solid>().TT==2)
                {
                    min = Vector3.Distance(i.transform.position, transform.position);
                    tmm = i;
                }
            }


        }

        if(tmm!=null)
        {
            Ball.transform.position = PointKick.position;
            Ball.transform.SetParent(null);          
            Ball.GetComponent<BallMove>().currentTarget = tmm.transform;
            Ball.AddComponent<Rigidbody>();
            Ball.GetComponent<Rigidbody>().useGravity = false;
            TTBall = true;


            tmm.GetComponent<Solid>().TT = 4;
            tmm.GetComponent<Rigidbody>().velocity = Vector3.zero;
            goc(tmm.transform.position, transform);

            anim.SetTrigger("kick");
            goc(transform.position, tmm.transform);
            transform.FindChild("chuyen").gameObject.SetActive(true);





            StartCoroutine(waitactive());
        }
        else
        {
            //Debug.Log("Lose");
            TT = 5;
            StartCoroutine(Defeat());
        }
    }

   IEnumerator waitactive()
    {
        TT = 0;

        yield return new WaitForSeconds(0.5f);

        transform.FindChild("Run").gameObject.SetActive(false);
        Set.SetActive(true);
        Set.GetComponent<Animator>().Play("Set");

        if(Chieu==1)
        transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
        anim.SetBool("run", false);
        transform.FindChild("Beta_Surface").gameObject.GetComponent<SkinnedMeshRenderer>().material = Gray;

        yield return new WaitForSeconds(2.5f);

        transform.FindChild("Beta_Surface").gameObject.GetComponent<SkinnedMeshRenderer>().material = TmMaterial;
        Set.SetActive(false);
        TT = 2;
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == DoiThu && TT==3 && other.GetComponent<SolidDef>().TT==2)
        {

            Nearnest();

            other.GetComponent<SolidDef>().Cham() ;
            other.GetComponent<SolidDef>().Target = null;
            other.gameObject.transform.FindChild("Range").gameObject.SetActive(false);

            //Debug.Log("co chua");
        }

        if(other.tag==GonDich)
        {
            if(TT==3 )
            {
               
                TTBall = false;
                Sl = 0;

                StartCoroutine(Win());
               
            }
            else if( TT == 5)
            {

            }
            else
            {
                Destroy(gameObject);
                GameObject Ef = Instantiate(ef, transform.position, Quaternion.identity);
                Destroy(Ef, 1.5f);
            }

        }

        if (other.tag =="destroy")
        {
            if (TT == 3)
            {
                TT = 5;
                StartCoroutine(Defeat());
            }
            else
            {
                Destroy(gameObject);
                Destroy(gameObject);
                GameObject Ef = Instantiate(ef, transform.position, Quaternion.identity);
                Destroy(Ef, 1.5f);
            }
        }
    }

    IEnumerator Defeat()
    {
        GameObject.Find("Music").transform.FindChild("end").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.FindChild("Pause").gameObject.SetActive(false);

        Camera.main.GetComponent<Animator>().Play("Camera");

        GameObject.Find("Canvas").transform.FindChild("WhoWin").gameObject.SetActive(true);
        if (gameObject.tag == "player2")
        {
            ManThongSo.win1++;
            GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER 1 WIN";

        }
        if (gameObject.tag == "player1")
        {
            ManThongSo.win2++;
            GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER 2 WIN";
        }

        ThongSo.Isrun = false;
        ThongSo.IsSpaw = false;
        
        GameObject[] listdd = GameObject.FindGameObjectsWithTag(DongDoi);
        GameObject[] listdt = GameObject.FindGameObjectsWithTag(DoiThu);

        foreach (GameObject i in listdd)
        {
            i.GetComponent<Solid>().TT = 5;
            i.transform.FindChild("vongvang").gameObject.SetActive(false);
            i.transform.FindChild("muiten").gameObject.SetActive(false);
            i.GetComponent<Solid>().anim.Play("defeat");
        }
        foreach (GameObject i in listdt)
        {
            i.GetComponent<SolidDef>().TT = 4;
            i.GetComponent<Animator>().Play("win");
            i.transform.FindChild("vongvang").gameObject.SetActive(false);
            i.transform.FindChild("muiten").gameObject.SetActive(false);
            i.transform.FindChild("Range").gameObject.SetActive(false);
            i.GetComponent<SolidDef>().enabled = false;
           
        }

        yield return new WaitForSeconds(5);
        ManThongSo.Match++;

        if (ManThongSo.Match >= 6)
        {
            if (ManThongSo.win1 == ManThongSo.win2)
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

    IEnumerator Win()
    {
        GameObject.Find("Music").transform.FindChild("end").gameObject.SetActive(true);
        transform.FindChild("goal").gameObject.SetActive(true);

        GameObject.Find("Canvas").transform.FindChild("Pause").gameObject.SetActive(false);

        Camera.main.GetComponent<Animator>().Play("Camera");

        GameObject.Find("Canvas").transform.FindChild("WhoWin").gameObject.SetActive(true);

        if (gameObject.tag=="player1")
        { 
            ManThongSo.win1++;
            GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER 1 WIN";

        }
        if (gameObject.tag == "player2") 
        { 
            ManThongSo.win2++;
            GameObject.Find("Canvas").transform.FindChild("WhoWin").GetComponent<Text>().text = "PLAYER 2 WIN";
        }


        ThongSo.Isrun = false;
        ThongSo.IsSpaw = false;
        GameObject[] listdd = GameObject.FindGameObjectsWithTag(DongDoi);
        GameObject[] listdt = GameObject.FindGameObjectsWithTag(DoiThu);

        foreach (GameObject i in listdd)
        {
            i.GetComponent<Solid>().TT = 5;
            i.transform.FindChild("vongvang").gameObject.SetActive(false);
            i.transform.FindChild("muiten").gameObject.SetActive(false);
            i.GetComponent<Solid>().anim.Play("win");
        }
        foreach (GameObject i in listdt)
        {
            i.GetComponent<SolidDef>().TT = 4;
            i.GetComponent<Animator>().Play("defeat");
            i.transform.FindChild("vongvang").gameObject.SetActive(false);
            i.transform.FindChild("muiten").gameObject.SetActive(false);
            i.transform.FindChild("Range").gameObject.SetActive(false);
            i.GetComponent<SolidDef>().enabled = false;

        }

        yield return new WaitForSeconds(5);
        ManThongSo.Match++;
   

        if (ManThongSo.Match >= 6)
        {
            if (ManThongSo.win1 == ManThongSo.win2)
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
