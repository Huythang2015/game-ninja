using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;



public class player : MonoBehaviour
{

    public float TGCho;
    public float tocdoTB;
    bool nhay = false;
    public float lucnhay;
    public float tocdo;
    public Rigidbody rigi;
    public Transform tranf;
    public static player instance;
   
    public Animator anim;
    Vector3 xoaydau;
   
    public Transform anhSangKiem;
    public Transform anhsangXia;
    Quaternion xoayKiem;
    bool KTMatDat;
    public ParticleSystem vetchem;
    public ParticleSystem vetchem2;
    float tgdanh;
    public ParticleSystem.RotationOverLifetimeModule xoayTronDoi2;
    public ParticleSystem.RotationOverLifetimeModule xoayTronDoi;
    public  Slider thanhTocBien;
    public float tocdobandau;
    float y;
    public tanCongVaMatMau tancongmatmau;
    float tg;
    public VariableJoystick variableJoystick;
    bool phai = false;
    bool trai = false;
    float x;
    Vector3 sangtrai;
    Vector3 sangphai;
    public void Awake()
    {
        instance = this;
        thanhTocBien = GameObject.FindWithTag("UI").transform.Find("thanh"). Find("thanhTocBien").GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // gán giá trị vào biến 
        tocdobandau = tocdo;
        xoayTronDoi = vetchem.rotationOverLifetime; 
        xoayTronDoi2 = vetchem2.rotationOverLifetime;
        thanhTocBien.maxValue = 3;
        
        

    }
    
// Update is called once per frame
    private void Update()
    {
         x = variableJoystick.Horizontal;
        if (y != transform.localEulerAngles.y)
        {
            y = transform.localEulerAngles.y;
        }
     
        
       
       
         
        if (TGCho > 0) // thoi gian cho de toc bien
        {
            thanhTocBien.value = TGCho;
            TGCho -= Time.deltaTime;
        }
        // toc bien
        else if (TGCho <= 0)
        {
            
            if (Input.GetKeyUp(KeyCode.V) || CrossPlatformInputManager.GetButtonUp ("tocbien")) // bam v de toc bien
            {
                if (tocdo > 0)                   
                {
                   
                        anim.Play("tocbien");
                        TGCho = 3;
                        //rigi.AddForce(new Vector3(tocdoTB, 0, 0) * Time.deltaTime,ForceMode.Impulse);
                      
                   


                }
            }
        }
       
        
        // di chuyen , chem, nhay
        // xoay vat the , vfx cho dung
        if (Input.GetKey(KeyCode.C) || x > 0) // xoay sang phai
        {


            transform.position = transform.position + new Vector3(1, 0, 0).normalized * tocdo * Time.deltaTime;

            //phai = true;
            //sangphai = new Vector3(x, 0, 0);
            

            anhSangKiem.localRotation = Quaternion.Euler(0, 0, 9.57f);
            anhsangXia.localScale = new Vector3(1, anhsangXia.localScale.y, anhsangXia.localScale.z);
            anim.SetBool("chay", true);
            xoaydau = transform.localScale;
            xoaydau.x *= -1;
            if (transform.localScale.x != 1)
                transform.localScale = xoaydau;
            if (xoayTronDoi.zMultiplier > 0)
            {
                xoayTronDoi.zMultiplier *= -1;
            }
            if (xoayTronDoi2.zMultiplier < 0)
            {
                xoayTronDoi2.zMultiplier *= -1;
            }
        }
        else if (Input.GetKey(KeyCode.Z) || x < 0) //bam nut z de sang trai dong thoi quay sang trai
        {
                       
            transform.position = transform.position + new Vector3(-1, 0, 0) * tocdo * Time.deltaTime;

            //trai = true;
            //sangtrai = new Vector3(x, 0, 0);


            anhsangXia.localScale = new Vector3(-1, anhsangXia.localScale.y, anhsangXia.localScale.z);
            anhSangKiem.localRotation = Quaternion.Euler(0, 0, -9.57f);
            anim.SetBool("chay", true);
            xoaydau = transform.localScale;
            xoaydau.x *= -1;
            if (transform.localScale.x == 1)
                transform.localScale = xoaydau;
            if ( xoayTronDoi.zMultiplier < 0) // xoay vfx
            {
                xoayTronDoi.zMultiplier *= -1;
            }
            if (xoayTronDoi2.zMultiplier > 0) // xoay vfx
            {
                xoayTronDoi2.zMultiplier *= -1;
            }

        }
        else
        {
            anim.SetBool("chay", false);
        }
        if (tgdanh > 0) // tg de danh
        {
            tgdanh -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.X) || CrossPlatformInputManager.GetButtonUp("danh"))
            {

                if (tgdanh <= 0)
                {
                    anim.SetBool("chem",true);
                    tgdanh = 0.5f;
                }

            }
        }
        
        if (Input.GetKeyDown(KeyCode.S) && KTMatDat == false  || CrossPlatformInputManager.GetButton("len") && KTMatDat == false)// nut nhay
        {
            Debug.Log("Jumped");
            
            anim.SetBool("nhay",true); // chạy anim nhảy
            rigi.AddForce(new Vector2 (0, 2f ) * lucnhay, ForceMode.Impulse); // thêm lực cho nó nhảy
            KTMatDat = true;
            tg = 0.2f;
        }
        if (tg > 0)
        {
            tg -= Time.deltaTime;
        }
       
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "KTMatDat")
        {
            
            if (tg <= 0)
            {
                anim.SetBool("nhay", false);
                
                KTMatDat = false;
            }

        }
    }
   
    public void savegame() //hàm này là để savegame
    {
        PlayerPrefs.SetInt("manchoi", SceneManager.GetActiveScene().buildIndex);
  
        Debug.Log(PlayerPrefs.GetInt("manchoi"));
    }
    public void Reset()
    {
        tancongmatmau.mau = tancongmatmau.maxMau;
    }
    private void FixedUpdate()
    {
        if (phai)
        {
            rigi.MovePosition(transform.position + sangphai * tocdo );
            phai = false;
        }
        else if (trai)
        {
            rigi.MovePosition(transform.position + sangtrai * tocdo);
            trai = false;
        }

    }


}
