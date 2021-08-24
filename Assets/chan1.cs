using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chan1 : MonoBehaviour
{
    public GameObject vfxcong;
    public GameObject nukiemsi;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.instance.transform.position.x > vfxcong.transform.position.x + 2)
        {
            if (vfxcong.activeSelf == false)
            {
                vfxcong.SetActive(true);
              
            }
            if (nukiemsi.activeSelf == false)
            {
                nukiemsi.SetActive(true);
            }
        }
        else if (player.instance.transform.position.x < vfxcong.transform.position.x - 2)
        {
            if (vfxcong.activeSelf == true)
            {
                vfxcong.SetActive(false);
                
            }
            if (nukiemsi.activeSelf == true)
            {
                nukiemsi.SetActive(false);
            }
        }
    }
}
