using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xoay : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject chon;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 x = chon.transform.position - transform.position;
        float y = Mathf.Atan2(x.y, x.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0, y + offset);
             
    }
}
