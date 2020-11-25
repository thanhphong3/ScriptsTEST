using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Slider> Bars;
    public  int Poin = 0;
    public int ViTriHT = 0;
    public int PointCost;
    
    void Start()
    {
        SetUp();
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    public void  SpawTT()
    {
        
            { Spaw(); }
    
    }
    void SetUp()
    {
        foreach(Slider i in Bars)
        {
            i.maxValue = 1;
            i.minValue = 0;
            i.value = 0;
        }
    }

    void RunBar()
    {
        if (ViTriHT <= 5)
        {

            if (Bars[ViTriHT].value != Bars[ViTriHT].maxValue)
            {
                Bars[ViTriHT].value += 0.5f;
            }
            else
            {
                Poin++;
                ViTriHT++;
            }
        }
        
    }
    IEnumerator wait()
    {
        if(ThongSo.Timecurrent<=15)
        yield return new WaitForSeconds(0.25f);
        else
            yield return new WaitForSeconds(0.5f);
        RunBar();
        StartCoroutine(wait());
    }

    void Spaw()
    {
        
        if(Poin==6)
        {
            SetUp();
            for (int i=0;i<Poin-PointCost;++i)
            {
                Bars[i].value = Bars[i].maxValue;
            }
            Poin -= PointCost;
            ViTriHT =Poin;
            

        }
else
        if (Poin >= PointCost)
        {
            float tmm = Bars[ViTriHT].value;

               SetUp();

        
            int tm =Poin- PointCost;
            Poin -= PointCost;
            try
            {
                for (int i = 0; i < tm; ++i)
                {
                    Bars[i].value = Bars[i].maxValue;
                }
            }
            catch { };
           
                ViTriHT = tm;
                Bars[ViTriHT].value = tmm;
            
            

        }
    }
}
