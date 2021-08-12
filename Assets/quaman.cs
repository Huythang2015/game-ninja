using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class quaman : MonoBehaviour
{
    bool chay ;
    public bool nuctacchet;
    public static quaman instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        nuctacchet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (nuctacchet == true)
        {
            SceneManager.LoadScene("man2");
        }
    }
}
