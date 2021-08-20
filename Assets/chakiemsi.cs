using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chakiemsi : MonoBehaviour
{
    float khoangcach;
    Transform kiemsi;
    Vector3 vitriBD;
    public float tocdodive;
    float khoangcachvitriBD;
    public GameObject linhtrang;
   
    // Start is called before the first frame update
    void Start()
    {
        kiemsi = transform.GetChild(0);
        vitriBD = kiemsi.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        khoangcach = Vector3.Distance(player.instance.transform.position, vitriBD);
        khoangcachvitriBD = Vector3.Distance(kiemsi. transform.position, vitriBD);
        if (khoangcach <= 50) // khi khoảng cách vs player mà nhỏ hơn hoặc = 50 thì
        {
            if (kiemsi.GetComponent<kiemsi>().slidermau.gameObject.active == false)
            {
                kiemsi.GetComponent<kiemsi>().slidermau.gameObject.SetActive(true);
            }
            if (kiemsi.gameObject.active == false)
            {
                kiemsi.gameObject. SetActive(true);
                kiemsi.transform.position = vitriBD;
               
            }
            if (linhtrang != null)
            {
                if (linhtrang.active == false)
                {
                    linhtrang.transform.position = vitriBD;
                    linhtrang.SetActive(true);
                }

            }

            //khi nào player chết đi thì thằng kiếm sĩ nếu còn sống sẽ đầy máu đồng thời bị tắt về vị trí ban đầu
            //khi nào player lại gần thì nó được bật và đánh nhau vs Player;




        }
       
            
        
    }
}
