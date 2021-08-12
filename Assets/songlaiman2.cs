using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songlaiman2 : MonoBehaviour
{
    public lintrang linh;
    public GameObject PLayer;
    public Transform noiHoiSinh;
    public static songlaiman2 instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PLayer = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hoisinh()
    {
        PLayer.transform.position = noiHoiSinh.position;
        kiemsi.instance.Reset();
        linh.Reset();

    }
}
