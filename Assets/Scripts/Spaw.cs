using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaw : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public EnergyBar BarEnergy1;
    public string Gonnha, GonDich,Field,Doithu;
    public float PointCost;

    public GameObject Ef1, Ef2;
    
    void Start()
    {
        SolidDef.Lock = false;
       Solid.TTBall = false;
       Solid.Sl = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && ThongSo.IsSpaw==true)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == Field)
            {
                if (BarEnergy1.Poin >= PointCost)
                {
                    if (gameObject.tag == "Scene")
                    {
                        if (Player.tag == "player1")
                        {
                            GameObject player1 = Instantiate(Player, hit.point, Quaternion.identity);
                            player1.GetComponent<SolidDef>().DoiThu = Doithu;
                            player1.GetComponent<SolidDef>().chieu = -1;
                           // player1.transform.rotation = Quaternion.Euler(0, 180, 0);
                            Vector3 tm = player1.transform.position;
                            tm.y = 0.5f;
                            player1.transform.position = tm;

                            
                           GameObject ef= Instantiate(Ef1, hit.point+new Vector3(0,1f,0), Quaternion.identity);
                            ef.transform.rotation=Quaternion.Euler(-90,0,0);
                            Destroy(ef, 4);
                        }
                        else
                        {
                           GameObject player1 = Instantiate(Player, hit.point, Quaternion.identity);
                            player1.GetComponent<Solid>().PointGon = GameObject.FindGameObjectWithTag(GonDich).transform;
                            player1.GetComponent<Solid>().GonDich = GonDich;
                            player1.GetComponent<Solid>().DongDoi = player1.tag;
                            player1.GetComponent<Solid>().DoiThu =Doithu;
                            player1.GetComponent<Solid>().Chieu = -1;
                            player1.transform.rotation = Quaternion.Euler(0, 180, 0);
                            Vector3 tm = player1.transform.position;
                            tm.y = 0.5f;
                            player1.transform.position = tm;

                            GameObject ef = Instantiate(Ef2, hit.point + new Vector3(0, 1f, 0), Quaternion.identity);
                            ef.transform.rotation = Quaternion.Euler(90, 0, 0);
                            Destroy(ef, 4);
                        }
                    }
                    else
                    {
                        if (Player.tag == "player1")
                        {
                            GameObject player1 = Instantiate(Player, hit.point, Quaternion.identity);
                            player1.GetComponent<Solid>().PointGon = GameObject.FindGameObjectWithTag(GonDich).transform;
                            player1.GetComponent<Solid>().GonDich = GonDich;
                            Vector3 tm = player1.transform.position;
                            tm.y = 0.5f;
                            player1.transform.position = tm;

                            GameObject ef = Instantiate(Ef1, hit.point + new Vector3(0, 1f, 0), Quaternion.identity);
                            ef.transform.rotation = Quaternion.Euler(-90, 0, 0);
                            Destroy(ef, 1);
                        }
                        else
                        {
                            GameObject player1 = Instantiate(Player, hit.point, Quaternion.identity);
                            player1.GetComponent<SolidDef>().DoiThu = Doithu;
                            player1.transform.rotation = Quaternion.Euler(0, 180, 0);
                            player1.GetComponent<SolidDef>().chieu = 1;
                            Vector3 tm = player1.transform.position;
                            tm.y = 0.5f;
                            player1.transform.position = tm;

                            GameObject ef = Instantiate(Ef2, hit.point + new Vector3(0, 1f, 0), Quaternion.identity);
                            ef.transform.rotation = Quaternion.Euler(90, 0, 0);
                            Destroy(ef, 1);
                        }
                    }
                 
                }
                BarEnergy1.SpawTT();
                
                
            }


        }
    }
}
