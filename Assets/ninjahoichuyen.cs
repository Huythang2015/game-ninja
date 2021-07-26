using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ninjahoichuyen : MonoBehaviour
{
    // cho chữ chạy trên màn hình
    //khởi tạo các biến
    public TextMeshProUGUI chuHien;
    public string[] danhsach;
    int sodong;
    float tocdo = 0.02f;
    bool khoidong = false;
    public BoxCollider boxnin;
    public GameObject chem;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        // nếu chữ chưa đầy thì chưa cho bấm
        if (chuHien.text == danhsach[sodong])
        {
            chem.SetActive(true);
            Debug.Log("hien");
        }
    }

    // Update is called once per frame
    // khi gọi hàm này thì lấy chữ đưa ra màn hình
    IEnumerator layChu()
    {
        foreach (char chu in danhsach[sodong].ToCharArray())
        {
            chuHien.text += chu;
            yield return new WaitForSeconds(tocdo);
        }
    }
    // hàm gọi chữ ra màn hình
    public void chuyenDong()
    {
        if (khoidong)
        {
            chem.SetActive(false);
            if (sodong < danhsach.Length - 1)
            {
                sodong++;
                chuHien.text = "";
                StartCoroutine(layChu());
            }
            else // khi bấm nút mà đang ở dòng cuối thì gọi những lệnh sau
            {
                chuHien.text = ""; // chữ sẽ không còn
                khoidong = false;
                
                ninjahoichuyen.Destroy(gameObject, 10); // xóa gameobj sau 10 giây
                chem.SetActive(true);
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KhuVucChiuSatThuong")
        {
            chem.SetActive(false);
            Debug.Log("an");
            chuHien.text = "";
            StartCoroutine(layChu());
           

            khoidong = true;
            boxnin.enabled = false;
        } 
    }
}
