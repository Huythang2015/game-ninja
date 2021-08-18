using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class satthuong : MonoBehaviour
{
    public float mau;
    public Animator anim;
    public static satthuong instance;
    public congngoai congngoai;
   
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
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("man1"))
            {
                congngoai.linhchet();
            }
           
            Destroy(gameObject.transform.parent.gameObject);
           
        }
  
    }
    public void Reset()
    {
        mau = 100;
    }
}
