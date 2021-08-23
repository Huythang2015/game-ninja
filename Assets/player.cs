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
    public bool nhaylen;
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
    public float x;
    Vector3 sangtrai;
    Vector3 sangphai;

    // biến để phục vụ việc tìm ra obj gần nhất
    public Transform TamPhatHien;
    public float doRongPhatHien;
    public LayerMask layerPhatHien;
    public GameObject enemygannhat = null;
    float khoangcachvsenemy = Mathf.Infinity;
    bool xoayphaikhidanh;
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
        if (enemygannhat != null)
        {
            xoaytheoenemy();
        }

        quayvaoenemy();
        
         x = variableJoystick.Horizontal;
    
    
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
           
         
          if (enemygannhat == null) // nếu enemygannhat = null thì mới được xoay tự do
            {
                // xoay vfx cho phù hợp vs Player
                if (xoayTronDoi.zMultiplier > 0)
                {
                    xoayTronDoi.zMultiplier *= -1;
                }
                if (xoayTronDoi2.zMultiplier < 0)
                {
                    xoayTronDoi2.zMultiplier *= -1;
                }
                anhSangKiem.localRotation = Quaternion.Euler(0, 0, 9.57f);
                anhsangXia.localScale = new Vector3(1, anhsangXia.localScale.y, anhsangXia.localScale.z);

                anim.SetBool("chay", true);
                anim.SetBool("chaylui", false);
                Debug.Log("null");
                if (transform.localScale.x < 0)
                {
                   
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                  
            }
          else
            {
                if (xoayphaikhidanh == true)
                {
                    anim.SetBool("chay", true);
                    anim.SetBool("chaylui", false);
                    // xoay vfx cho phù hợp vs Player
                    if (xoayTronDoi.zMultiplier > 0)
                    {
                        xoayTronDoi.zMultiplier *= -1;
                    }
                    if (xoayTronDoi2.zMultiplier < 0)
                    {
                        xoayTronDoi2.zMultiplier *= -1;
                    }
                    anhSangKiem.localRotation = Quaternion.Euler(0, 0, 9.57f);
                    anhsangXia.localScale = new Vector3(1, anhsangXia.localScale.y, anhsangXia.localScale.z);
                }
                else
                {
                    anim.SetBool("chay", false);
                    anim.SetBool("chaylui", true);

                    if (xoayTronDoi.zMultiplier < 0) // xoay vfx
                    {
                        xoayTronDoi.zMultiplier *= -1;
                    }
                    if (xoayTronDoi2.zMultiplier > 0) // xoay vfx
                    {
                        xoayTronDoi2.zMultiplier *= -1;
                    }
                    anhsangXia.localScale = new Vector3(-1, anhsangXia.localScale.y, anhsangXia.localScale.z);
                    anhSangKiem.localRotation = Quaternion.Euler(0, 0, -9.57f);
                }
            }

           
            
           
        }
        else if (Input.GetKey(KeyCode.Z) || x < 0) //bam nut z de sang trai dong thoi quay sang trai
        {
                       
            transform.position = transform.position + new Vector3(-1, 0, 0) * tocdo * Time.deltaTime;

            
           
            if (enemygannhat == null)// nếu enemygannhat = null thì mới được xoay tự do
            {
                // xoay vfx theo Player
                if (xoayTronDoi.zMultiplier < 0) // xoay vfx
                {
                    xoayTronDoi.zMultiplier *= -1;
                }
                if (xoayTronDoi2.zMultiplier > 0) // xoay vfx
                {
                    xoayTronDoi2.zMultiplier *= -1;
                }
                anhsangXia.localScale = new Vector3(-1, anhsangXia.localScale.y, anhsangXia.localScale.z);
                anhSangKiem.localRotation = Quaternion.Euler(0, 0, -9.57f);

                anim.SetBool("chay", true);
                anim.SetBool("chaylui", false);
                if (transform.localScale.x > 0)
                {
                    
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                   
            }
            else
            {
                if (xoayphaikhidanh == true)
                {
                    anim.SetBool("chay", false);
                    anim.SetBool("chaylui", true);

                    // xoay vfx cho phù hợp vs Player
                    if (xoayTronDoi.zMultiplier > 0)
                    {
                        xoayTronDoi.zMultiplier *= -1;
                    }
                    if (xoayTronDoi2.zMultiplier < 0)
                    {
                        xoayTronDoi2.zMultiplier *= -1;
                    }
                    anhSangKiem.localRotation = Quaternion.Euler(0, 0, 9.57f);
                    anhsangXia.localScale = new Vector3(1, anhsangXia.localScale.y, anhsangXia.localScale.z);
                }
                else
                {
                    anim.SetBool("chay", true);
                    anim.SetBool("chaylui", false);

                    if (xoayTronDoi.zMultiplier < 0) // xoay vfx
                    {
                        xoayTronDoi.zMultiplier *= -1;
                    }
                    if (xoayTronDoi2.zMultiplier > 0) // xoay vfx
                    {
                        xoayTronDoi2.zMultiplier *= -1;
                    }
                    anhsangXia.localScale = new Vector3(-1, anhsangXia.localScale.y, anhsangXia.localScale.z);
                    anhSangKiem.localRotation = Quaternion.Euler(0, 0, -9.57f);
                }
            }


            
        }
        else
        {
            anim.SetBool("chay", false);
            anim.SetBool("chaylui", false);
        }

        // sử lý việc đánh. hết tg hồi đánh thì ms đc đánh
        if (tgdanh > 0) // tg de danh
        {
            tgdanh -= Time.deltaTime; // 
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
        
        if (Input.GetKeyDown(KeyCode.S) && nhaylen == false  || CrossPlatformInputManager.GetButton("len") && nhaylen == false)// nut nhay
        {
            Debug.Log("Jumped");
            
            anim.SetBool("nhay",true); // chạy anim nhảy
            rigi.AddForce(new Vector2 (0, 2f ) * lucnhay, ForceMode.Impulse); // thêm lực cho nó nhảy
            nhaylen = true;
            tg = 0.2f;
        }
        if (tg > 0) 
        {
            tg -= Time.deltaTime;
        }
       
    }
    
    private void OnCollisionStay(Collision collision) // kiểm tra xem có chạm đất không
    {
        if (collision.gameObject.tag == "KTMatDat")
        {
            
            if (tg <= 0)
            {
                anim.SetBool("nhay", false);
                
                nhaylen = false;
            }

        }
    }
   //
    public void savegame() //hàm này là để savegame
    {
        PlayerPrefs.SetInt("manchoi", SceneManager.GetActiveScene().buildIndex);
  
        Debug.Log(PlayerPrefs.GetInt("manchoi"));
    }
    public void Reset() // reset các thứ khi bị chết
    {
        tancongmatmau.mau = tancongmatmau.maxMau;
        tancongmatmau.thanhmau.value = tancongmatmau.mau;
    }
    private void FixedUpdate()
    {
        // đi sang phải và sang trái
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
    // hàm kiểm tra enemy nào gần nhất trong khoảng
    public GameObject  quayvaoenemy() // tim enemy gan nhat
    {
        khoangcachvsenemy = Mathf.Infinity;
        Collider[] Eenemy = Physics.OverlapSphere(TamPhatHien.position, doRongPhatHien, layerPhatHien); // tạo khu vực phát hiện enemy
        
        bool Enemy = Physics.CheckSphere(TamPhatHien.position, doRongPhatHien, layerPhatHien); // kiem tra xem khu vực phát hiện enemy có trống ko nếu trống = false và ngược lại
        if (Enemy == false) //  khu vực phát hiện enemy trống thì
        {
            khoangcachvsenemy = Mathf.Infinity; //biến khoảng cách về dương vô cực
            enemygannhat = null; // biến enemygannhat = null

        }
        // đo đạc khoảng cách giữa các enemy tìm enemy gần nhất trong khoảng hình chòn
        // ko có ko gọi
        foreach (Collider enemy in Eenemy) 
        {
          
            Vector2 vtdotam = enemy.transform.position - transform.position;
            float sodotam = vtdotam.sqrMagnitude; // tìm ra khoảng cách 
           
            if (sodotam < khoangcachvsenemy)
            {             
                enemygannhat = enemy.gameObject;
                khoangcachvsenemy = sodotam;
                Debug.Log(sodotam + enemygannhat.name);
            }          
        }      
        return enemygannhat;
    }
    void xoaytheoenemy() // xoay theo enemy gần nhất
    {
        if (enemygannhat.transform.position.x > transform.position.x) // nếu người chơi đứng bên trái enemy gần nhất thì
        {
            xoayphaikhidanh = true; // player xoay phải = true;
            if (transform.localScale.x < 0)
            {            
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }          
        }
        else
        {
            xoayphaikhidanh = false; // player đang xoay trái
            if (transform.localScale.x > 0)
            {
                
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
    private void OnDrawGizmosSelected() // hiển thị các khu vực bắt collider 1 cách trực quan
    {
        Gizmos.color = Color.red; // tô màu đỏ
        Gizmos.DrawWireSphere(TamPhatHien.position, doRongPhatHien);
       
    }
}
