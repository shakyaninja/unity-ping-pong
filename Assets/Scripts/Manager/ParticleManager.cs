using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;
    public ParticleSystem[] particleSystems; // Array of particle systems to spawn
    public Transform parentTransform; // Parent transform for the spawned particles

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnParticleAtLocation(Vector2 spawnPosition)
    {
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            Vector3 spawnPosition3D = new Vector3(spawnPosition.x, spawnPosition.y, 0f);
            ParticleSystem spawnedParticleSystem = Instantiate(particleSystem, spawnPosition3D, Quaternion.identity, parentTransform);
            spawnedParticleSystem.Play();
        }
    }
}
