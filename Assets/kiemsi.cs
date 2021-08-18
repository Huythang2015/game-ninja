using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiemsi : MonoBehaviour
{
    public Animator anim;
    bool chieu2 = false; 
    bool chieu1 = false;
    public Transform Diemchieu1;
    public Transform diemChieu2;
    public float phamViChieu2;
    public float phamvichieu1;// điểm chém hoặc điểm gây sát thương của chiêu 1
    public LayerMask layerPlayer;
    public float maxMau;
    public float mau;
    public static kiemsi instance;
    float khoangcach;
    Vector3 vitriBD;
    public GameObject chancau;
    public GameObject quaman;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mau = maxMau;
        vitriBD = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // su ly chieu
        if (chieu1 == true)
        {
            Collider[] Player = Physics.OverlapSphere(Diemchieu1.position, phamvichieu1, layerPlayer);
            foreach(Collider player in Player)
            {
                if (player.transform.parent.GetComponent<tanCongVaMatMau>() != null)
                {
                    player.transform.parent.GetComponent<tanCongVaMatMau>().satthuong(10);
                    stopchieu1();
                }
               
            }
        }
        if (chieu2 == true)
        {
            Collider[] Player = Physics.OverlapSphere(diemChieu2.position, phamViChieu2, layerPlayer);
            foreach (Collider player in Player)
            {
                if (player.transform.parent.GetComponent<tanCongVaMatMau>() != null)
                {
                    player.transform.parent.GetComponent<tanCongVaMatMau>().satthuong(10);
                    stopchieu1();
                }

            }
        }

        if (gameObject.active == true) // nếu kiếm sĩ hoạt động thì
        {
            khoangcach = Vector3.Distance(player.instance.transform.position, vitriBD);
            if (khoangcach <= 50)
            {
                if (transform.position.x > player.instance.transform.position.x + 1) // nếu vị trí kiếm sĩ lớn hon player thì
                {
                    if (transform.localScale.x < 0) // nếu sclae x của kiemsi mà đang lớn hơn 0 thì
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); // cho nó nhỏ hơn 0 bằng
                                                                                                                                         // nhân vs -1
                    }

                }
                else if (transform.position.x < player.instance.transform.position.x - 1) // ngược lại thôi
                {
                    if (transform.localScale.x > 0)
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    }
                }
            }
            else
            {
                if (transform.position.x < vitriBD.x ) // nếu vị trí kiếm sĩ lớn hon player thì
                {
                    if (transform.localScale.x > 0) // nếu sclae x của kiemsi mà đang lớn hơn 0 thì
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); // cho nó nhỏ hơn 0 bằng
                                                                                                                                         // nhân vs -1
                    }

                }
                else if (transform.position.x > vitriBD.x) // ngược lại thôi
                {
                    if (transform.localScale.x < 0)
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    }
                }
            }
           
        }
        
    }

    public void stchieu1()
    {
        chieu1 = true;
    }
    public void stopchieu1()
    {
        chieu1 = false;
    }
    public void stchieu2()
    {
        chieu2 = true;
    }
    public void stopchieu2()
    {
        chieu2 = false;
    }
    public void matMau(int dam)
    {
        mau -= dam; 
        if (mau <= 0)
        {
            quaman.SetActive(true);
            Destroy(chancau, 5);
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        
        mau = maxMau;
        gameObject.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Diemchieu1.position, phamvichieu1);
        Gizmos.DrawWireSphere(diemChieu2.position, phamViChieu2);


    }

}
