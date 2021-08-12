using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerr : MonoBehaviour
{
    public float tocdoxoay;
    public Transform pody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float chuotx = Input.GetAxis("Mouse X") * tocdoxoay * Time.deltaTime;
        pody.Rotate (Vector3.up * chuotx);
    }
}
