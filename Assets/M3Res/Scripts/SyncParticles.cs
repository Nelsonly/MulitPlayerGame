using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncParticles : MonoBehaviour
{
    public ParticleSystem[] particles;

    void OnEnable()
    {
        int seed = Random.Range(0, 1000000);
        for (int i = 0; i < particles.Length; i++) {
            particles[i].Stop();
            particles[i].useAutoRandomSeed = false;
            particles[i].randomSeed = (uint)seed;
            particles[i].Play();
        }
    }

}
