using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nutac : MonoBehaviour
{
    public Rigidbody rigidan;
    public GameObject Player;
    public GameObject dan;
    public Transform nongsung;
    Vector3 huongxoay;
    public float chieu;
    bool chem = false;
    bool da = false;
    public Transform ViTriChem;
    public float PhamViChem;
    public LayerMask layerPlayer;
    public ParticleSystem vetchem , vetda;
    public static nutac instance;
    void Start()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Update()
    { 
        //xoay nutac
        if (player .instance.transform.position.x < transform.position.x && transform.localScale .x > 0)
        {
            var xoaytrondoichem = vetchem.rotationOverLifetime;
            if (xoaytrondoichem.zMultiplier < 0)
            {
                xoaytrondoichem.zMultiplier *= -1;
            }
            var xoaytrondoida = vetda.rotationOverLifetime;
            if (xoaytrondoida.zMultiplier > 0)
            {
                xoaytrondoida.zMultiplier *= -1;
            }

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (player.instance.transform.position.x > transform.position.x && transform.localScale .x < 0)
        {
            var xoaytrondoida = vetda.rotationOverLifetime;
            if (xoaytrondoida.zMultiplier < 0)
            {
                xoaytrondoida.zMultiplier *= -1;
            }
            var xoaytrondoichem = vetchem.rotationOverLifetime;
            if (xoaytrondoichem.zMultiplier > 0)
            {
                xoaytrondoichem.zMultiplier *= -1;
            }

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        // su ly viec chem giet
        if (chem == true || da == true)        {
            Collider[] Player = Physics.OverlapSphere(ViTriChem.position, PhamViChem, layerPlayer);
            foreach(Collider player in Player)
            {
                tanCongVaMatMau.instance.satthuong(10);
                ngungchem();
                stopda();
            }
        }
    }
    //Cac phong sun su ly viec ban , chem
    public void nutacban()
    {
        Instantiate(dan, nongsung.position, dan.transform.rotation);
    }
    public void kichhoatchem()
    {
        chem = true;
    }
    public void ngungchem()
    {
        chem = false;
    }
    public void kichhoatda()
    {
        da = true;
    }
    public void stopda()
    {
        da = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ViTriChem.position, PhamViChem);
    }
   

}
