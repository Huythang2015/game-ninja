using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lintrang : MonoBehaviour
{
    bool chem = false;
    public Transform vitriChem;
    public float dorongChem;
    public LayerMask layerPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( chem == true)
        {
            Collider[] Player = Physics.OverlapSphere(vitriChem.position, dorongChem, layerPlayer);
            foreach (Collider player in Player)
            {
                player.GetComponent<tanCongVaMatMau>().satthuong(10);
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
}
