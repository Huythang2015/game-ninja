using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class diemluu1 : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("ok");
        if (Input.GetKeyDown(KeyCode.X) || CrossPlatformInputManager.GetButtonUp("danh"))
        {
            SongLai.instance.vitriSongLai = transform;
        }

    }
}
