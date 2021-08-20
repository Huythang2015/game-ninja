using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dannutac : MonoBehaviour
{
    public float chieu;
    public Rigidbody rigi;
    public float tocdo;
    Vector3 huongxoay;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        amthanh.PlayAmThanh("luavutqua");
        huongxoay = player.instance.transform.position - transform.position;
        Vector3 huongdi = (player.instance.transform.position - transform.position).normalized * tocdo;
        rigi.velocity = new Vector3(huongdi.x, huongdi.y,huongdi.z);
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 huongxoay = player.instance.transform.position - transform.position;
        float xoay = Mathf.Atan2(huongxoay.y, huongxoay.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, xoay + chieu);
        
        
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
