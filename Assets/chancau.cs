using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chancau : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (player.instance.transform.position.x > transform.position.x + 2)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if (player.instance.transform.position.x < transform.position.x - 2)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
