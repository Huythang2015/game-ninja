using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class binhMau : MonoBehaviour
{
    public static binhMau BinhMau;
    public int binhmau;
    public Text sobinh;

    // Start is called before the first frame update
    void Start()
    {
        binhmau = 1;
        sobinh.text = "" + binhmau;
    }

   
    public void sudungmau()
    {
        if (binhmau > 0)
        {
            binhmau -= 1;
            tanCongVaMatMau.instance.mau += 50;
            tanCongVaMatMau.instance.thanhmau.value = tanCongVaMatMau.instance.mau;
            sobinh.text = "" + binhmau;
            if (tanCongVaMatMau.instance.mau > 100)
            {
                tanCongVaMatMau.instance.mau = tanCongVaMatMau.instance.maxMau;
            }
        }
       
    }
}
