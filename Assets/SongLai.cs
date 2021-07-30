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
    public void HoiSinh(  )
    {
       GameObject Player = Instantiate(Playerprefap, vitriSongLai.position, Quaternion.identity);
        cam.Follow = Player.transform.GetChild(0).GetChild(0) ;
        satthuong.instance.Reset();
        conglon.instance.Reset();

        satthuongtac.instance.Reset();
        
    }
}
