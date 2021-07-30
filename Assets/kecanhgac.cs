using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kecanhgac : MonoBehaviour
{
    public float tocdo;
    bool di;
    public Rigidbody rigi;
    Vector3 xoayenemy;
    bool stChem;
    public Transform ViTriSTChem;
    public float PhamviSTChem;
    public LayerMask playerLayer;
    public GameObject Pplayer;
    public Animator anim;
    Vector3 viTriBandau;
    Vector3 huongVe;
    public ParticleSystem vetChem;
    public ParticleSystem xien;
    float khoangcach;
    public static kecanhgac instance;
    // Start is called before the first frame update
    void Start()
    {
        viTriBandau = transform.position;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        var TDTronDoi = xien.velocityOverLifetime;
        var xoayTronDoi = vetChem.rotationOverLifetime;
        khoangcach = Vector3.Distance(player.instance.transform.position, viTriBandau);
        if (khoangcach > 40)
        {
           
            anim.SetTrigger("dive");
            huongVe = (viTriBandau - transform.position).normalized * tocdo;
            rigi.velocity = new Vector3(huongVe.x , rigi.velocity.y);
        }
        else
        {
            anim.SetTrigger("hoatdong");
        }


        // xoay theo Player
        if (player.instance.transform.position.x > transform.position.x + 1)
        {
            if (xoayTronDoi.zMultiplier < 0)
            {
                xoayTronDoi.zMultiplier *= -1;
            }

            if (TDTronDoi.xMultiplier > 0)
            {
                TDTronDoi.x = new ParticleSystem.MinMaxCurve(-50);
            }


            xoayenemy = transform.localScale;
            xoayenemy.x *= -1;
            if (transform.localScale.x > 0)
            {
                // Debug.Log("so");
                transform.localScale = xoayenemy;
            }

        }
        else if (player.instance.transform.position.x < transform.position.x - 1)
        {
            if (xoayTronDoi.zMultiplier > 0)
            {
                xoayTronDoi.zMultiplier *= -1;
            }
            if (TDTronDoi.xMultiplier < 0)
            {
                TDTronDoi.x = new ParticleSystem.MinMaxCurve(50);
            }
            

            xoayenemy = transform.localScale;
            xoayenemy.x *= -1;
        
            if (transform.localScale.x < 0)
            {
               // Debug.Log("so");
                transform.localScale = xoayenemy;
            }

        }

       
        if ( stChem == true)
        {
            Collider[] khuVucChem = Physics.OverlapSphere (ViTriSTChem.position, PhamviSTChem, playerLayer);
            foreach (Collider Player in khuVucChem)
            {
                Debug.Log(Player.name);
                if (Player.tag == "KhuVucChiuSatThuong")
                {

                    //player.instance.transform.GetComponent<tanCongVaMatMau>().satthuong(10);
                    player.instance.GetComponent<tanCongVaMatMau>().satthuong(10);
                    stChem = false;
                }
            }
        }
    }
   


    // phan sat thuong
    public void satthuongchem()
    {
        stChem = true;
    }
    public void stopSatThuongChem()
    {
        stChem = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ViTriSTChem .position, PhamviSTChem);
    }
   
}
