using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nutacbidau : MonoBehaviour
{
    public float mau;
    public float maxmau;
    // Start is called before the first frame update
    void Start()
    {
        mau = maxmau;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void satthuongnutac(int dam)
    {
        mau -= dam;
    }
}
