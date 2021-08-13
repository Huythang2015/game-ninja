using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class batdau : MonoBehaviour
{

    public string manluu;
   

    public void batdautudau () // bấm nút bắt đầu thì
    {
        SceneManager.LoadScene("man1"); // bắt đầu thì load màn 1
        PlayerPrefs.DeleteKey("manchoi"); // xóa mọi màn đã lưu
    }
    public void tieptuc() // bấm nút tiếp thục thì
    {

        SceneManager.LoadScene(PlayerPrefs.GetInt("manchoi",1)); // load màn chơi đã lưu mà nếu chưa lưu thì load màn 1
    }
    
}
