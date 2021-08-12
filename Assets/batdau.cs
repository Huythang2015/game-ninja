using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class batdau : MonoBehaviour
{

    public string manluu;
    private void Start()
    {
       
    }

    public void batdautudau (){
        SceneManager.LoadScene("man1");

        }
    public void tieptuc()
    {

        SceneManager.LoadScene(PlayerPrefs.GetString("manluu"));
    }
    public void savegame()
    {
        Debug.Log("save");
        manluu = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("manluu", manluu);
    }
}
