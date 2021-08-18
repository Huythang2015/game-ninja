using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class batdau : MonoBehaviour
{
    public GameObject load;
    public Slider slide;
    public string manluu;
   

    public void batdautudau () // bấm nút bắt đầu thì
    {
        PlayerPrefs.DeleteKey("manchoi"); // xóa mọi màn đã lưu
        StartCoroutine(loadman(PlayerPrefs.GetInt("manchoi",1 )));       
    }
    public void tieptuc() // bấm nút tiếp thục thì
    {
        StartCoroutine(loadman(PlayerPrefs.GetInt("manchoi", 1)));       // load màn chơi đã lưu mà nếu chưa lưu thì load màn 1
    }
    IEnumerator loadman(int manchoi)
    {
        //yield return new WaitForSeconds(10);
        load.SetActive(true);
        AsyncOperation opera = SceneManager.LoadSceneAsync(manchoi);

      
        while (!opera.isDone)
        {
            float pro = Mathf.Clamp01(opera.progress / 0.9f);
            Debug.Log(pro);
            
            slide.value = pro;
            
            yield return null ;
        }
       
    }
    
   

}
