using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuttamdung : MonoBehaviour
{
    public GameObject khichoi;
    public GameObject pauseMenu;
    public void tamdung() // khi nhấn nút tạm dừng thì
    {
        Debug.Log("ok");
        // bat hoac tat menu tam dung
        if (khichoi.active)
        {
            khichoi.active = false;
        }
        else
        {
            khichoi.active = true;
        }  
        
       if (pauseMenu.active)
        {
            pauseMenu.active = false;
        }
        else
        {
            pauseMenu.active = true;
        }
     }
}
