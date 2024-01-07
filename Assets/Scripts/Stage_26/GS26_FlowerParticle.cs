using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS26_FlowerParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem flowerParticlePrefab;

    public void Spawn()
    {

        ParticleSystem flowerParticle = Instantiate(flowerParticlePrefab, flowerParticlePrefab.transform.position, flowerParticlePrefab.transform.rotation, flowerParticlePrefab.transform.parent);
        flowerParticle.Play();
        Destroy(flowerParticle.gameObject, flowerParticle.main.duration);
    }
}
