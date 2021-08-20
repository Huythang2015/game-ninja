using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class satthuongtac : MonoBehaviour
{
    public GameObject thanhhp;
    public Slider thanhmau;
    public float maxmau;
    public float mau;
    Vector3 vitribandau;
    public Animator anim;
    public static satthuongtac instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mau = maxmau;
        thanhmau.maxValue = maxmau;
        thanhmau.value = mau;
        vitribandau = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void satthuong(float dam) // sử lý sát thương
    {
        anim.SetTrigger("bidau");
        mau -= dam;
        thanhmau.value = mau;
        
        if (mau <= 0)
        {
            Destroy(gameObject);
            quaman.instance.nuctacchet = true;
        }
    }
    public void Reset()
    {
        mau = maxmau;
        thanhmau.value = mau;
        gameObject.GetComponent<Animator>().enabled = false;
        transform.position = vitribandau;
        thanhhp.SetActive(false);
        
    }
}