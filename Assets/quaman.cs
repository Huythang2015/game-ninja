using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quaman : MonoBehaviour
{
    public Slider slide;
    public GameObject load;
    bool chay ;
    public bool nuctacchet;
    public static quaman instance;
    public GameObject kiemsi;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        nuctacchet = false;
    }

    // Update is called once per frame
   
    IEnumerator loadman()
    {
        //yield return new WaitForSeconds(10);
        load.SetActive(true);
        AsyncOperation opera = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);


        while (!opera.isDone)
        {
            float pro = Mathf.Clamp01(opera.progress / 0.9f);
            Debug.Log(pro);

            slide.value = pro;

            yield return null;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("man2"))
        {
            if (kiemsi == null)
            {
                StartCoroutine(loadman());
            }
           
        }
        

        if (nuctacchet == true && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("man1"))
        {
            StartCoroutine(loadman());
        }
    }
}
