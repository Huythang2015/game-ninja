using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class diemxoaytren : MonoBehaviour
{
    public bool re = false;
    public TextMeshProUGUI chu;
    private void OnTriggerEnter(Collider other)
    {
        re = true;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.transform);
        if (other.tag == "KhuVucChiuSatThuong" && re == true && player.instance.transform.localScale.x == -1)
        {
            chu.text = "Bam A de re";
            if (Input.GetKeyDown(KeyCode.A))
            {

                player.instance.GetComponent<Animator>().SetTrigger("rexuong");
                re = false;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        re = false;
        chu.text = "";
    }
}
