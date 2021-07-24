using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoctapxoay : MonoBehaviour
{
    float a = 4;
    public ParticleSystem phaohoa;
    public ParticleSystem.RotationOverLifetimeModule rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = phaohoa.rotationOverLifetime;
        rotation.z = 4;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
