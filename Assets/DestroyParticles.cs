using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    // [SerializeField] private float delay;
    [SerializeField] private ParticleSystem _particleSystem;
    void Start()
    {
        Destroy(this,_particleSystem.duration);   
    }
}
