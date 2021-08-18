using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chancau : MonoBehaviour
{
    bool bat;

    // Update is called once per frame
    void Update()
    {
        if (player.instance.transform.position.x > transform.position.x + 2)
        {     
            if (bat == false)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                transform.GetChild(0).gameObject.SetActive(true);
                bat = true;
            }
          
            
        }
        else if (player.instance.transform.position.x < transform.position.x - 2)
        {
            if (bat == true)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
                bat = false;
            }
          
        }
    }
}
