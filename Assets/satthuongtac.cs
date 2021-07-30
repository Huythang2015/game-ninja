using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class satthuongtac : MonoBehaviour
{
    public Slider thanhmau;
    public float maxmau;
    public float mau;
    Vector3 vitribandau;
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
    public void satthuong(float dam)
    {
        mau -= dam;
        thanhmau.value = mau;
    }
    public void Reset()
    {
        mau = maxmau;
        thanhmau.value = mau;
        gameObject.GetComponent<Animator>().enabled = false;
        transform.position = vitribandau;
    }
}