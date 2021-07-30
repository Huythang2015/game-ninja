using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class satthuong : MonoBehaviour
{
    public float mau;
    public Animator anim;
    public static satthuong instance; 
   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mau = 100;
    }

    public void matMau(int dam)
    {
        mau -= dam;
        if (anim != null)
        {
            anim.SetTrigger("bidau");
        }
        if (mau <= 0)
        {
            Destroy(gameObject.transform.parent.parent.gameObject);
        }
  
    }
    public void Reset()
    {
        mau = 100;
    }
}
