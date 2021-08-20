using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songlaiman2 : MonoBehaviour
{
    public lintrang linh;
    public GameObject PLayer;
    
    public static songlaiman2 instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PLayer = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

  
    public void hoisinh(Transform diemluu)
    {
        PLayer.transform.position = diemluu.position;
        if (player.instance != null)
        {
            player.instance.Reset();
        }
        
        if(kiemsi.instance != null)
        {
            kiemsi.instance.Reset();
        }

       
        linh.Reset();

    }
}
