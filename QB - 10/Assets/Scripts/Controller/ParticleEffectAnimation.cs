using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectAnimation : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void ActivateParticleSystem()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}
