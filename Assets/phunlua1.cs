using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phunlua1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "KhuVucChiuSatThuong")
        {
            tanCongVaMatMau.instance.satthuong(3);
        }
        
    }
    
}
