using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danNTK : MonoBehaviour
{
    public Rigidbody rigi;
    public float tocdo;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 huongdi = (player.instance.transform.position - transform.position).normalized * tocdo;
        rigi.velocity = new Vector3(huongdi.x, huongdi.y, huongdi.z);
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "KhuVucChiuSatThuong")
        {
            amthanh.PlayAmThanh("minno");
            tanCongVaMatMau.instance.satthuong(10);
            Destroy(gameObject);
        }
    }
}
