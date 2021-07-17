using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
   
    
    bool nhay = false;
    public float lucnhay;
    public float tocdo;
    public Rigidbody2D rigi;
    public Transform tranf;
    public static player instance;
    public BoxCollider2D ktnhay;
    public Animator anim;
    Vector2 xoaydau;
    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        // di chuyen , chem, nhay
       
        if (Input.GetKey(KeyCode.C) || CrossPlatformInputManager.GetButton ("phai"))
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * tocdo * Time.deltaTime;
            anim.SetBool("chay", true);
            xoaydau = transform.localScale;
            xoaydau.x = 1;
            transform.localScale = xoaydau;
        }
        else if (Input.GetKey(KeyCode.Z)  || CrossPlatformInputManager.GetButton ("trai"))
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * tocdo * Time.deltaTime;
            anim.SetBool("chay", true);
            xoaydau = transform.localScale;
            xoaydau.x = -1;
            transform.localScale = xoaydau;
        }
        else 
        {
            anim.SetBool("chay", false);
        }
        if (Input.GetKeyDown (KeyCode.X) || CrossPlatformInputManager.GetButtonUp("danh"))
        {
            anim.SetTrigger("chem");
        }
        if (Input.GetKey(KeyCode.S) && nhay == false || CrossPlatformInputManager.GetButtonUp("len") && nhay == false)
        {
            nhay = true;
            anim.SetBool ("nhay",true);
            rigi.AddForce(transform.up * lucnhay * Time.deltaTime, ForceMode2D.Impulse);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MatDat")
        {
            nhay = false;
            anim.SetBool("nhay", false);
        }
    }

}
