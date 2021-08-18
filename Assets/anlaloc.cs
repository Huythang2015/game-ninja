using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anlaloc : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("ok");
            Touch touch = Input.GetTouch(0);
            Vector3 viTriCham = Camera.main.ScreenToWorldPoint(touch.position);
            viTriCham.z = -993.73f;
            transform.position = viTriCham;

        }
    }
}
