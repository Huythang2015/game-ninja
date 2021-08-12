using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chakiemsi : MonoBehaviour
{
    float khoangcach;
    Transform kiemsi;
    Vector3 vitriBD;
    public float tocdodive;
    float khoangcachvitriBD;
    public GameObject linhtrang;
    // Start is called before the first frame update
    void Start()
    {
        kiemsi = transform.GetChild(0);
        vitriBD = kiemsi.transform.position;
        Debug.Log(kiemsi.name);
    }

    // Update is called once per frame
    void Update()
    {
       
        khoangcach = Vector3.Distance(player.instance.transform.position, vitriBD);
        khoangcachvitriBD = Vector3.Distance(kiemsi. transform.position, vitriBD);
        if (khoangcach <= 50) // khi khoảng cách vs player mà nhỏ hơn hoặc = 50 thì
        {
            if (kiemsi.gameObject.active == false)
            {
                kiemsi.gameObject.SetActive(true);
            }
           if (linhtrang.active == false)
            {
                linhtrang.SetActive(true);
            }
            
                
            
           
           
            
        }
       /* else // khoảng cách vs player lớn hơn 50 thi
        {
            if (khoangcachvitriBD >= 3)
            {
                kiemsi.GetComponent<Animator>().Play("dive", 0);
               
            }
           
            
            if (khoangcachvitriBD < 3) 
            {
               if (kiemsi.gameObject.active = true)
                {
                    kiemsi.gameObject.SetActive(false);
                }
                
               

            }
          
            
        }*/
            
        
    }
}
