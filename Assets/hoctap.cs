using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoctap : MonoBehaviour
{
    public Vector3 ht;
    public Transform tran;
    // Start is called before the first frame update
    void Start()
    {
        //tran.Rotate(ht, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        tran.localRotation = Quaternion.Euler(1,1,8.5f);
    }
}
