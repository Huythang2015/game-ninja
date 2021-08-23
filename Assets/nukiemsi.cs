using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nukiemsi : MonoBehaviour
{
    public float maxmau;
    public float mau;
    Transform viTriplayer;
    public bool chieu1 = false;
    public Transform ViTrichieu1;
    public float phamvichhieu1;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        viTriplayer = GameObject.Find("nhanvat").transform;
        mau = maxmau;
    }

    // Update is called once per frame
    void Update()
    {
        if (viTriplayer.position.x > transform.position.x + 1)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
          
        }
        else if (viTriplayer.position.x < transform.position.x - 1)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

        }
        if (chieu1 == true)
        {
            Collider[] khuVucChem = Physics.OverlapSphere(ViTrichieu1 .position, phamvichhieu1, playerLayer);
            foreach (Collider Player in khuVucChem)
            {

                if (Player.tag == "KhuVucChiuSatThuong")
                {
                    amthanh.PlayAmThanh("enemychem");
                   
                    
                    player.instance.GetComponent<tanCongVaMatMau>().satthuong(10);
                    chieu1 = false;
                }
            }
        }
    }
    public void truMau(int dam)
    {
        mau -= dam;
        if (mau <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void BatDauChieu1()
    {
        chieu1 = true;
    }
    public void stopchieu1()
    {
        chieu1 = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ViTrichieu1.position, phamvichhieu1);
    }
}
