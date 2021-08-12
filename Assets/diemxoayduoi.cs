using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityStandardAssets.CrossPlatformInput;

public class diemxoayduoi : MonoBehaviour
{
    public bool re = false;
    public TextMeshProUGUI chu ;
    public float tocdokhichay;
    public bool trong;
    public static diemxoayduoi instance;
    float y;
    
    private void Start()
    {
        instance = this;
        tocdokhichay = player.instance.tocdo;
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KhuVucChiuSatThuong" )
        {
            re = true;
            trong = true;
        }
            
        
        
    }
    private void OnTriggerStay(Collider other)
    {
        y = player.instance.transform.localEulerAngles .y;
        Debug.Log(y);
        if (other.tag == "KhuVucChiuSatThuong" && re == true) // nếu va chạm vs player thì:
        {
          
            chu.text = "Bam Chem de re"; // va chạm thì chữ hiện lên
            if (y == -90f) // nếu trục y rotation mà bằng -90 thì
            {
                if (player.instance.transform.localScale.x == -1) //nếu scale trục x = 1 thì
                {
                    player.instance.tocdo = 0; // tốc độ player = 0
                  
                }
                else if (player.instance.transform.localScale.x == 1) // còn nếu = 1 thì
                {
                    player.instance.tocdo = tocdokhichay; // tốc độ player dữ nguyên
                    
                } 
            }
            else if (y == 0f) // còn nếu trục y rotation player mà bằng 0 thì 
                
            {
                Debug.Log(tocdokhichay);
                player.instance.tocdo = tocdokhichay; // tốc độ player dữ nguyên
              
            }
            if (Input.GetKeyDown(KeyCode.A) || CrossPlatformInputManager.GetButtonDown ("danh") ) // nếu bấm a thì 
            {
                if (y == 0f) // nếu trục y rotation player = 0 thì
                {
                    player.instance.GetComponent<Animator>().SetBool("relen",true);// animator player gọi set bool relen = true
                    re = false; // re = sai
                    
                }
                else if (y != 0f)
                {
                    player.instance.GetComponent<Animator>().SetBool ("rexuong", true);
                    re = false;
                    
                }


            }
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        trong = false;
        re = false;
        chu.text = "";
        player.instance.tocdo = tocdokhichay;
    }
}
