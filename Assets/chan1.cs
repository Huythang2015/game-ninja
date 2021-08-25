using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chan1 : MonoBehaviour
{
    public GameObject vfxcong;
    public GameObject Enemy;
    public TextMeshProUGUI chu ;
    float time;
    public string chaoNhau;
    

    // Update is called once per frame
    void Update()
    {
        // nếu đi qua cổng này
        // cổng này sẽ bị đóng
        // nếu giết chết boss thì cổng này sẽ bị xóa
        // nếu trục x player nhỏ hơn trục x cổng này thì
        //boss sẽ tắt
        // nếu trục x player lớn hơn trục x cổng này thì 
        // boss sẽ bật
        // mỗi khi boss được bật 
        // boss sẽ đầy ặc máu
        if (player.instance.transform.position.x > vfxcong.transform.position.x + 2)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }            
            if (time >= 0)
            {
                chu.text = chaoNhau;
            }
            else
            {
                chu.text = "";
            }


            if (vfxcong.activeSelf == false)
            {
                vfxcong.SetActive(true);
              
            }
            if (Enemy.activeSelf == false)
            {
                Enemy.SetActive(true);
                time = 3;
                if (Enemy.GetComponent<nukiemsi>() != null)
                {
                    Enemy.GetComponent<nukiemsi>().mau = Enemy.GetComponent<nukiemsi>().maxmau;
                }
                if (Enemy.GetComponent<quaivat2dau>() != null)
                {
                    Enemy.GetComponent<quaivat2dau>().mau = Enemy.GetComponent<quaivat2dau>().maxMau;
                }
                
                
               
            }

           
        }
        else if (player.instance.transform.position.x < vfxcong.transform.position.x - 2)
        {
            if (vfxcong.activeSelf == true)
            {
                vfxcong.SetActive(false);
                
            }
            if (Enemy.activeSelf == true)
            {
                Enemy.SetActive(false);
            }
        }
    }
}
