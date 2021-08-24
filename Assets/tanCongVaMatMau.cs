using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

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
    public Animator anim;
    public Transform viTriLuu;
    public GameObject songLai;

    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lever1 = SceneManager.GetSceneByName("man1"); // cho lever1 = man 1
        
       
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
                        amthanh.PlayAmThanh("chemchung");
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
                        amthanh.PlayAmThanh("chemchung");
                        enemy.GetComponent<kiemsi>().matMau(10);
                        ngungChem();
                        
                    }
                    if (enemy.GetComponent<lintrang>() != null)
                    {
                        amthanh.PlayAmThanh("chemchung");
                        enemy.GetComponent<lintrang>().matMau(10);
                    }
                    if (enemy.GetComponent<satthuongtac>() != null)
                    {
                       
                        amthanh.PlayAmThanh("chemchung");
                        enemy.GetComponent<satthuongtac>().satthuong(10);
                        ngungChem();
                    }
                    if (enemy.GetComponent<nukiemsi>() != null)
                    {
                        amthanh.PlayAmThanh("chemchung");
                        enemy.GetComponent<nukiemsi>().truMau(10);
                        ngungChem();
                    }

                }
            }
        }
       
    }
    public void satthuong(float dam)
    {
        anim.Play("choang");
        mau -= dam;
        thanhmau.value = mau;
        
        if (mau <= 0) // su ly hoi sinh
        {
            if (SceneManager.GetActiveScene() == lever1) // neu o man1 thi xoa player
            {
              
                SongLai.instance.HoiSinh(viTriLuu.position);

            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
            {
                songlaiman2.instance.hoisinh(viTriLuu);
                
            }
            else
            {
               
                songLai.GetComponent<hoisinhman3>().hoisinh(viTriLuu);
               
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "diemLuu")
        {
           
                if (other.transform != viTriLuu)
                {
                    Debug.Log(other.name);
                    viTriLuu = other.transform;
                }
                      
        }
    }

}
