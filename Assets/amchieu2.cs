using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amchieu2 : MonoBehaviour
{
    public BoxCollider chieu2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ok");
        if (other.tag == "KhuVucChiuSatThuong")
        {
            tanCongVaMatMau.instance.satthuong(1);
            chieu2.enabled = false;
        }
    }
}
