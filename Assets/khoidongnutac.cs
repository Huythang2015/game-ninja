using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class khoidongnutac : MonoBehaviour
{
    public Animator nutac;
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KhuVucChiuSatThuong")
        {
            conglon.instance.transform.localPosition = new Vector3
                (conglon.instance.transform.localPosition.x, 6.7f, conglon.instance.transform.localPosition.z);
            
            if (satthuongtac.instance.gameObject != null)
            {
                nutac.enabled = true;
                satthuongtac.instance.thanhhp.SetActive(true);
            }
        }
    }
}
