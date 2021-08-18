using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class diemluu1 : MonoBehaviour
{
    public TextMeshProUGUI luu;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "KhuVucChiuSatThuong")
        {           
            luu.text = "điểm lưu";
        }
        

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "KhuVucChiuSatThuong")
        {
            luu.text = null;
        }
        
    }

}
