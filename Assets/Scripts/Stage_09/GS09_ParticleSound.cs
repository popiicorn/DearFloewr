using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS09_ParticleSound : MonoBehaviour
{
    bool gameClear = false;
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("WaterGround") && gameClear == false)
        {

            Debug.Log("hit");
            CriManager.instance.Play3D();

        }
    }

    public void stopDropSound()
    {
        gameClear = true;
    }

}
