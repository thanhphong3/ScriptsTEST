using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    // Start is called before the first frame update
    SolidDef cha;
    void Start()
    {
        cha = transform.GetComponentInParent<SolidDef>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (cha.DoiThu == other.tag && other.GetComponent<Solid>().TT == 3 && SolidDef.Lock == false)
        {
            if (gameObject == Nearnest(other.transform.position))
            {
               // Debug.Log("Da phat hien ra");
                
                cha.Target = other.gameObject;
                SolidDef.Lock = true;
                gameObject.SetActive(false);
            }

        }
    }

    GameObject Nearnest(Vector3 target)
    {
        GameObject[] listp = GameObject.FindGameObjectsWithTag("range");
        float min = 100f;
        GameObject tmm = null;
        foreach (GameObject i in listp)
        {

            if (Vector3.Distance(i.transform.position, target) < min)
            {
                min = Vector3.Distance(i.transform.position, target);
                tmm = i;
            }

        }

        return tmm;
    }

}