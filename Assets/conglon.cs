using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conglon : MonoBehaviour
{
    public static conglon instance;
    Vector3 cong;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        cong = transform.localPosition;
    }

    public void Reset()
    {
        transform.localPosition = cong;
        Debug.Log(cong);
    }

}
