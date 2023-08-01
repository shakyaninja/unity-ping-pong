using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    // Call this function to spawn particles at a given Vector2 location
    public void SpawnParticlesAt(Vector2 spawnPosition)
    {
        ParticleManager.Instance.SpawnParticleAtLocation(spawnPosition);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
