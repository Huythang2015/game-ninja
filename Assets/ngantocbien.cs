using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ngantocbien : MonoBehaviour
{
    public GameObject tocbien;
    

   private void OnTriggerStay(Collider other)
    {
        

    
            if (other.tag == "KhuVucChiuSatThuong")
            {
            if (tocbien.active == true)
                tocbien.SetActive(false);
            }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "KhuVucChiuSatThuong")
        {
            tocbien.SetActive(true);
        }
    }
}
