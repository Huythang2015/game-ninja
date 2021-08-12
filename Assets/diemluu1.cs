using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class diemluu1 : MonoBehaviour
{
    public TextMeshProUGUI luu;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "KhuVucChiuSatThuong")
        {
            if (Input.GetKeyDown(KeyCode.X) || CrossPlatformInputManager.GetButtonUp("danh"))
            {
                SongLai.instance.vitriSongLai = transform;
            }

            luu.text = "bấm chém để lưu";
        }
        

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "KhuVucChiuSatThuong")
        {
            luu.text = null;
        }
        
    }

}
