using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoisinhman3 : MonoBehaviour
{
    public GameObject PLayer;
    public nukiemsi nukiemsi;

    // Start is called before the first frame update
    void Start()
    {
        PLayer = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    public void hoisinh(Transform diemluu)
    {
        PLayer.transform.position = diemluu.position;
        nukiemsi.Reset();
        player.instance.Reset();
    }
}
