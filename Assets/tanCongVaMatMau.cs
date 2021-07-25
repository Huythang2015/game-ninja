using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tanCongVaMatMau : MonoBehaviour
{
    bool choChem;
    public float maxMau = 100;
    float mau;
    public Slider thanhmau;
    public Transform diemChem;
    public float phamViChem;
    public LayerMask layerKeThu;

    // Start is called before the first frame update
    void Start()
    {
        mau = maxMau;
        thanhmau.maxValue = maxMau;
        thanhmau.value = mau;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (choChem == true)
        {
            Collider2D[] KhuVucChem = Physics2D.OverlapCircleAll(diemChem.position, phamViChem, layerKeThu);
            foreach(Collider2D enemy in KhuVucChem) // kiem tra enemy nao trong khu vuc chem 
            {
                if ( enemy.tag == "enemy")
                {
                    if ( enemy.GetComponent<satthuong>() != null)
                    {
                        enemy.GetComponent<satthuong>().matMau(10);
                        ngungChem();
                    }
                }
            }
        }
    }
    public void satthuong(float dam)
    {
        mau -= dam;
        thanhmau.value = mau;
    }
    public void chem()
    {
         choChem = true;
    }
    public void ngungChem()
    {
        choChem = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(diemChem.position, phamViChem);
    }
   
}
