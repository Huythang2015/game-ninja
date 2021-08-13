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
    public BoxCollider2D ktnhay;
    public Animator anim;
    Vector3 xoaydau;
    Vector3 xoaydau2;
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
   

public void Awake()
    {
        instance = this;
        thanhTocBien = GameObject.FindWithTag("UI").transform.Find("khichoi"). Find("thanhTocBien").GetComponent<Slider>();
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
        
        y = transform.localEulerAngles.y;
        Debug.Log(y);
        if (y == 0)
        {
            if (rigi.constraints != RigidbodyConstraints.FreezePositionZ)
            {
                rigi.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

            }
        }
        else if (y != 0)
        {
            if (rigi.constraints != RigidbodyConstraints.FreezePositionX )
            {
                rigi.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
               
                
            }
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
                    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("man1"))
                    {
                        if (transform.localScale.x < 0)
                        {
                            thanhTocBien.value = TGCho;
                            TocBien(-1);
                            TGCho = 3;
                        }
                        if (transform.localScale.x > 0)
                        {
                            thanhTocBien.value = TGCho;
                            TocBien(1);
                            TGCho = 3;
                        }
                    } 
                    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("man2"))
                    {
                        anim.Play("tocbien");
                        TGCho = 3;
                    }


                }
            }
        }
       
        
        // di chuyen , chem, nhay
        // xoay vat the , vfx cho dung
        if (Input.GetKey(KeyCode.C) || CrossPlatformInputManager.GetButton("phai")) // xoay sang phai
        {
            if (y == 0 
                ||  SceneManager.GetSceneByName("man1") == SceneManager.GetActiveScene())
            {
               
                transform.position = transform.position + new Vector3(1, 0, 0) * tocdo * Time.deltaTime;
                Debug.Log(SceneManager.GetActiveScene().name);
            }
            else if (y != 0)
            {

                transform.position = transform.position + new Vector3(0, 0, 1) * tocdo * Time.deltaTime;
            }

            //anim.enabled = false;

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
        else if (Input.GetKey(KeyCode.Z) || CrossPlatformInputManager.GetButton("trai")) //bam nut z de sang trai dong thoi quay sang trai
        {
            if (y == 0
                 || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("man1"))
            {               
                transform.position = transform.position + new Vector3(-1, 0, 0) * tocdo * Time.deltaTime;
               

            }
            else if (y != 0)
            {
                
                   

                transform.position = transform.position + new Vector3(0, 0, -1) * tocdo * Time.deltaTime;
            }
               
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
        
        if (Input.GetKey(KeyCode.S) && KTMatDat == false  || CrossPlatformInputManager.GetButtonUp("len") && KTMatDat == false)// nut nhay
        {
            
            anim.SetBool ("nhay",true); // chạy anim nhảy
            rigi.AddForce(new Vector2 (0, 2f ) * lucnhay, ForceMode.Force); // thêm lực cho nó nhảy
            KTMatDat = true; 
        }
        
       
    }
    private void OnCollisionStay(Collision collision) // check mat dat . chạm mặt đất mới cho nhảy
    {
        if (collision.gameObject.tag == "KTMatDat")
        {
            KTMatDat = false;
            anim.SetBool("nhay", false);
        }
    }
    public void TocBien(int x) // gọi hàm này thì Player tốc biến
    {
        player.instance.transform.position += new Vector3(x, 0, 0) * tocdoTB * Time.deltaTime;
    }
    public void savegame() //hàm này là để savegame
    {
        PlayerPrefs.SetInt("manchoi", SceneManager.GetActiveScene().buildIndex);
        Debug.Log(PlayerPrefs.GetInt("manchoi"));
    }
    

}
