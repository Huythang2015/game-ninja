using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhaytuong : MonoBehaviour
{
    public Transform diemPhatHienTuong;
    bool diemchamTuong;
    bool dachamtuong;
    public float phamviphathien;
    public LayerMask tuong;
    public Rigidbody rigi; // rigi cua Player
    public float tocDoChuot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diemchamTuong = Physics.CheckSphere(diemPhatHienTuong.position, phamviphathien, tuong); // diem cham tuong dc kich hoat
        if (diemchamTuong == true && player.instance.nhaylen == true  )
        {
            dachamtuong = true;
            Debug.Log("ok");
        }
        else
        {
            dachamtuong = false;
        }
        if (dachamtuong)
        {
            rigi.velocity = new Vector3(rigi.velocity.x, Mathf.Clamp(rigi.velocity.y, -tocDoChuot, float.MaxValue));
        }
    }
}
