using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = player.instance.transform.localRotation;
        Debug.Log(transform.localRotation.y);
    }
}
