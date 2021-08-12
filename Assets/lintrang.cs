using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lintrang : MonoBehaviour
{
    bool chem = false;
    public Transform vitriChem;
    public float dorongChem;
    public LayerMask layerPlayer;
    public float mau;

    // Start is called before the first frame update
    void Start()
    {
        mau = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.instance.transform.position.x > transform.position.x)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
           
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
           
        }
        
        if ( chem == true)
        {
            Collider[] Player = Physics.OverlapSphere(vitriChem.position, dorongChem, layerPlayer);
            foreach (Collider player in Player)
            {
                if (player.transform.parent.GetComponent<tanCongVaMatMau>() != null)
                player.transform.parent.  GetComponent<tanCongVaMatMau>().satthuong(10);
                chem = false;
            }
        }
    }
    public void danh()
    {
        chem = true;
    }
    public void ngungdanh()
    {
        chem = false;
    }
    public void Reset()
    {
        mau = 200;
    }
    public void matMau(int dam)
    {
        mau -= dam;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(vitriChem.position, dorongChem);
    }
}
