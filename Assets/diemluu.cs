using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class diemluu : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "KhuVucChiuSatThuong")
        {
            if (Input.GetKeyDown(KeyCode.X) || CrossPlatformInputManager.GetButtonUp("danh"))
            {
                SongLai.instance.vitriSongLai = transform;
            }
        }
        
            
    }
   
}
