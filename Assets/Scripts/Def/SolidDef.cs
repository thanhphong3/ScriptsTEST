using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidDef : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Animator anim;
    public string DoiThu = "player1";
    public int TT = 0;

    public bool Warn = false;
    public GameObject Target=null;
    GameObject Con;
    public Vector3 PointStart;

    public static bool Lock;

    public float Angle = 180;

    GameObject Set;

    public int chieu=1;
    public Material Gray;
    Material TmMaterial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Con = transform.FindChild("Range").gameObject;
        PointStart = transform.position;

        Set = transform.FindChild("SetPefabs").gameObject;
        Set.active = false;

        StartCoroutine(wait0());

        TmMaterial = transform.FindChild("Beta_Surface").gameObject.GetComponent<SkinnedMeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Lock +" "+Warn);



        if(TT==1)
        {
            transform.FindChild("Run").gameObject.SetActive(false);
            if (Target!=null)
            {
                
                transform.FindChild("muiten").gameObject.SetActive(true);
                TT = 2;
                Con.SetActive(false);
               
            }
        
         
         
        }

        if(TT==2)
        {
            transform.FindChild("Run").gameObject.SetActive(true);
            Con.SetActive(false);
            transform.FindChild("vongvang").gameObject.SetActive(true);
            goc(transform.position, Target.transform.position);
            Move(Target.transform.position, 1.5f);
            anim.SetBool("run", true);
        }

        if(TT==3)
        {
            transform.FindChild("Run").gameObject.SetActive(true);
            Con.SetActive(false);
            goc(transform.position,PointStart );
            Move(PointStart, 2f);
            anim.SetBool("run", true);
            ReturnPoint();
        }

        if(TT==4)
        {
            Con.SetActive(false);
            rb.velocity = Vector3.zero;
            transform.FindChild("Run").gameObject.SetActive(false);
            this.enabled = false;

        }
    }


    void ReturnPoint()
    {
        if (transform.position == PointStart)
        {
            Con.SetActive(false);
            StartCoroutine(waitchamtaikichhoat());

        }
    }

    IEnumerator wait0()
    {
        TT = 0;
        Con.SetActive(false);
        
        yield return new WaitForSeconds(0.5f);
        TT = 1;
       
        Con.SetActive(true);

    }

   public  void Cham()
    {
        StartCoroutine(waitcham());
    }
    IEnumerator waitcham()
    {
        TT = 0;
        anim.SetBool("run", false);
        

        yield return new WaitForSeconds(0.6f);
      
        TT = 3;    
    }
    IEnumerator waitchamtaikichhoat()
    {
        transform.FindChild("vongvang").gameObject.SetActive(false);
        Set.SetActive(true);
        Set.GetComponent<Animator>().Play("set4s");
        transform.FindChild("muiten").gameObject.SetActive(false);
        anim.SetBool("run", false);

        if (chieu == 1)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.FindChild("Beta_Surface").gameObject.GetComponent<SkinnedMeshRenderer>().material = Gray;

        if (ThongSo.Timecurrent<=15)
        {
            yield return new WaitForSeconds(0f);   
        }
        else
        {
            yield return new WaitForSeconds(4f);
        }

        transform.FindChild("Beta_Surface").gameObject.GetComponent<SkinnedMeshRenderer>().material = TmMaterial;
        Set.SetActive(false);
        Con.SetActive(true);
        TT = 1;


    }

    void goc(Vector3 here, Vector3 tt)
    {

        Vector3 mousePos = tt;


        // Vector3 here = transform.position;
        Vector3 lookDir = mousePos - here;


        float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    void Move(Vector3 tt, float speed)
    {

        Vector3 newPos = Vector3.MoveTowards(transform.position, tt, speed * Time.deltaTime);

        rb.MovePosition(newPos);
    }
}
