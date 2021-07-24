using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satthuong : MonoBehaviour
{
    public float mau;
    // Start is called before the first frame update
    void Start()
    {
        mau = 100;
    }

    public void matMau(int dam)
    {
        mau -= dam;
    }
}
