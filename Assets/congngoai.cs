using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class congngoai : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int soLinhChet;
    public BoxCollider boxcongngoai;

   
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "KhuVucChiuSatThuong")
        {
            text.text = "ta phải giết mấy tên cho hả";

        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "KhuVucChiuSatThuong")
        {
            text.text = "";

        }
    }
    public void linhchet()
    {
        soLinhChet += 1;
        if (soLinhChet >= 5)
        {
            boxcongngoai.enabled = false;
        }
    }
}
