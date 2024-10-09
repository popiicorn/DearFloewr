using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS09_ParticleSound : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("WaterGround"))
        {
            Debug.Log("hit");

        }
    }
}