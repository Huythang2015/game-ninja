using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tanCongVaMatMau : MonoBehaviour
{
    bool choChem;
    public float maxMau = 100;
    public float mau;
    public Slider thanhmau;
    public Transform diemChem;
    public float phamViChem;
    public LayerMask layerKeThu;
    public static tanCongVaMatMau instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mau = maxMau;
        thanhmau = GameObject.Find("thanhmauPlayer").GetComponent<Slider>();
        
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
        if (choChem == true)
        {
            Collider[] KhuVucChem = Physics.OverlapSphere (diemChem.position, phamViChem, layerKeThu);
            foreach (Collider enemy in KhuVucChem)
            {
                if (enemy.GetComponent<satthuongtac>() != null)
                {
                    if (enemy.tag == "enemy")
                    {
                        enemy.GetComponent<satthuongtac>().satthuong(10);
                        ngungChem();
                    }
                   
                }
            }
            // kiem tra enemy nao trong khu vuc chem 
        }
    }
    public void satthuong(float dam)
    {
        
        mau -= dam;
        thanhmau.value = mau;
        if (mau <= 0) // su ly hoi sinh
        {
            Destroy(gameObject.transform.parent.gameObject);
            SongLai.instance.HoiSinh();
            
            
        }
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
