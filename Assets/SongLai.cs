using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SongLai : MonoBehaviour
{
    public static SongLai instance;
    public Transform vitriSongLai;
    public GameObject Playerprefap;
    public CinemachineVirtualCamera cam;

     


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HoiSinh(Vector3 vitriLuu)
    {
        player.instance.transform.position = vitriLuu;
        player.instance.Reset(); // resetplayer;
        satthuong.instance.Reset();
        conglon.instance.Reset();
        if (satthuong.instance.gameObject != null)
        {
            satthuongtac.instance.Reset();
        }
        
        
    }
}
