using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Scene lever1;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lever1 = SceneManager.GetSceneByBuildIndex (1); // cho lever1 = man 1
        
       
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
            Collider[] khuvucchem = Physics.OverlapSphere(diemChem.position, phamViChem, layerKeThu);
            foreach (Collider enemy in khuvucchem)  // kiem tra eney nao trong khu vuc chem
            {
                if (enemy.tag == "enemy")
                {
                    if (enemy.GetComponent<kiemsi>() != null)
                    {
                        enemy.GetComponent<kiemsi>().matMau(10);
                        ngungChem();
                        
                    }
                    if (enemy.GetComponent<lintrang>() != null)
                    {
                        enemy.GetComponent<lintrang>().matMau(10);
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
            if (SceneManager.GetActiveScene() == lever1) // neu o man1 thi xoa player
            {
                Destroy(gameObject.transform.parent.gameObject);
                SongLai.instance.HoiSinh();

            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
            {
                songlaiman2.instance.hoisinh();
                
            }


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
    private void OnDrawGizmosSelected() // hen thi khu vuc chem truc quan
    {
        Gizmos.DrawWireSphere(diemChem.position, phamViChem);
    }
    
}
