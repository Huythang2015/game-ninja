using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nukiemsi : MonoBehaviour
{
    public float maxmau;
    public float mau;
    Transform viTriplayer;
    public bool chieu1 = false;
    public Transform ViTrichieu1;
    public float phamvichhieu1;
    public LayerMask playerLayer;
    public GameObject dan;
    public Transform vitriBan;
    public GameObject chan1;
    public Slider thanhMau;
    
    // Start is called before the first frame update
    void Start()
    {
        viTriplayer = GameObject.Find("nhanvat").transform;
        mau = maxmau;
        thanhMau.maxValue = maxmau;
        thanhMau.value = mau;

    }

    // Update is called once per frame
    void Update()
    {
      
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
        thanhMau.value = mau;
        if (mau <= 0)
        {
            Destroy(chan1, 3);
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
    public void bandan()
    { 
        Instantiate(dan, vitriBan.position, dan.transform.rotation);
    }
    public void Reset()
    {
        mau = maxmau;
        thanhMau.value = mau;
    }
}
