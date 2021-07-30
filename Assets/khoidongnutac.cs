using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khoidongnutac : MonoBehaviour
{
    public Animator nutac;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KhuVucChiuSatThuong")
        {
            conglon.instance.transform.localPosition = new Vector3
                (conglon.instance.transform.localPosition.x, 6.7f, conglon.instance.transform.localPosition.z);
            nutac.enabled = true;
        }
    }
}
