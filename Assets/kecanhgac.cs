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
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.instance.transform.position.x > transform.position.x)
        {
            
            xoayenemy = transform.localScale;
            xoayenemy.x *= -1;
            if (transform.localScale.x >0)
            {
               // Debug.Log("so");
                transform.localScale = xoayenemy;
            }
           
        }
        else if (player.instance.transform.position.x < transform.position.x)
        {

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
                    
                    Pplayer.transform.parent.GetComponent<tanCongVaMatMau>().satthuong(10);
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
