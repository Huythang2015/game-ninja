using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasthit : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit coi;
        if (Physics.Raycast(transform.position, transform.right, out coi, 100f))
        {
            Debug.Log(coi.transform.name);
        }

    }
    void a()
    {
        
    }
}
