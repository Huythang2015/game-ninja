using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anhsangkiem : MonoBehaviour
{
    public Vector3 anhSangKiem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anhSangKiem = transform.Find("Particle System2").eulerAngles;
        Debug.Log(anhSangKiem);
    }
}
