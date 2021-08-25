using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaivat2dau : MonoBehaviour
{
    bool mo2 = false;
    bool mo = false;
    public Transform[]  viTriMo;
    public float phamViMo;
    public LayerMask layerPlayer;
    public float mau;
    public float maxMau;
    
    // Start is called before the first frame update
    void Start()
    {
        mau = maxMau;
    }

    // Update is called once per frame
    void Update()
    {
       if (mo == true) // nếu con rồng nó mổ
        {
            Collider[] Player = Physics.OverlapSphere(viTriMo[0].position, phamViMo, layerPlayer);
            foreach (Collider player in Player)
            {
                tanCongVaMatMau.instance.satthuong(10);
                mo = false;
            }
        }
        if (mo2 == true) // nếu con rồng nó mổ
        {
            Collider[] Player = Physics.OverlapSphere(viTriMo[1].position, phamViMo, layerPlayer);
            foreach (Collider player in Player)
            {
                tanCongVaMatMau.instance.satthuong(10);
                mo2 = false;
            }
        }
    }
    public void Mo()
    {
        mo = true;
    }
    public void stopMo()
    {
        mo = false;
    }
    public void Mo2()
    {
        mo2 = true;
    }
    public void stopMo2()
    {
        mo2 = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(viTriMo[1].position, phamViMo);
        Gizmos.DrawWireSphere(viTriMo[0].position, phamViMo);
    }
    public void matMau(int dam)
    {
        mau -= dam;
    }
}
