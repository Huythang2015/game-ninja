using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amthanh : MonoBehaviour
{
    public static  AudioClip playerchem, enemychem, minno, luaVutQua;
    public static AudioSource loa;
    // Start is called before the first frame update
    void Start()
    {
        luaVutQua = Resources.Load<AudioClip>("amthanh/tiengluavutqua");
        minno = Resources.Load<AudioClip>("amthanh/minNo");
        playerchem = Resources.Load<AudioClip>("amthanh/sethit") ;
        enemychem = Resources.Load<AudioClip>("amthanh/gaysuong");
        loa = gameObject.GetComponent<AudioSource>();
    }
    public static void PlayAmThanh(string tenAT)
    {
        switch (tenAT)
        {
            case ("chemchung"): // player chém chúng enemy
                loa.PlayOneShot(playerchem);
                break;
            case ("enemychem"): // enemy chem chúng player
                loa.PlayOneShot(enemychem);
                break;
            case ("minno"):
                loa.PlayOneShot(minno);
                break;
            case ("luavutqua"):
                loa.PlayOneShot(luaVutQua);
                break;
        }
    }
    
}
