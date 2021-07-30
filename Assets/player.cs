using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


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
    Quaternion xoayKiem;
    bool KTMatDat;
    public ParticleSystem vetchem;

    
    public ParticleSystem.RotationOverLifetimeModule xoayTronDoi;


public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        xoayTronDoi = vetchem.rotationOverLifetime;
        
    }
    
// Update is called once per frame
    private void Update()
    {
        
        if (TGCho > 0)
        {
            TGCho -= Time.deltaTime;
        }
        // toc bien
        else if (TGCho <= 0)
        {
            if (Input.GetKeyUp(KeyCode.V))
            {
                if (transform.localScale.x < 0)
                {
                    TocBien(1);
                    TGCho = 3;
                }
                if (transform.localScale.x > 0)
                {
                    TocBien(-1);
                    TGCho = 3;
                }
            }
        }
       
        
        // di chuyen , chem, nhay
        // xoay vat the , vfx cho dung
        if (Input.GetKey(KeyCode.C) || CrossPlatformInputManager.GetButton("phai"))
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * tocdo * Time.deltaTime;
         
            //anim.enabled = false;

            anhSangKiem.localRotation = Quaternion.Euler(0, 0, 9.57f);
           
            anim.SetBool("chay", true);
            xoaydau = transform.localScale;
            xoaydau.x *= -1;
            if (transform.localScale.x != 1)
                transform.localScale = xoaydau;
            if (xoayTronDoi.zMultiplier > 0)
            {
                xoayTronDoi.zMultiplier *= -1;
            }
        }
        else if (Input.GetKey(KeyCode.Z) || CrossPlatformInputManager.GetButton("trai"))
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * tocdo * Time.deltaTime;

            anhSangKiem.localRotation = Quaternion.Euler(0, 0, -9.57f);
            anim.SetBool("chay", true);
            xoaydau = transform.localScale;
            xoaydau.x *= -1;
            if (transform.localScale.x == 1)
                transform.localScale = xoaydau;
            if ( xoayTronDoi.zMultiplier < 0)
            {
                xoayTronDoi.zMultiplier *= -1;
            }


        }
        else
        {
            anim.SetBool("chay", false);
        }

        if (Input.GetKeyDown (KeyCode.X) || CrossPlatformInputManager.GetButtonUp("danh"))
        {
            anim.SetTrigger("chem");
        }
        if (Input.GetKey(KeyCode.S) && KTMatDat == false  || CrossPlatformInputManager.GetButtonUp("len") && KTMatDat == false)
        {
            
            anim.SetBool ("nhay",true);
            rigi.AddForce(new Vector2 (0, 2f ) * lucnhay, ForceMode.Force);
            KTMatDat = true;
        }
        
       
    }
    private void OnCollisionStay(Collision collision) // check mat dat
    {
        if (collision.gameObject.tag == "KTMatDat")
        {
            KTMatDat = false;
            anim.SetBool("nhay", false);
        }
    }
    public void TocBien(int x)
    {
        player.instance.transform.position += new Vector3(x, 0, 0) * tocdoTB * Time.deltaTime;
    }


}
