using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectAnimation : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem particleSystem;

    void Start()
    {
        animator = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Method to trigger the particle effect
    public void PlayParticleEffect()
    {
        // Trigger the "PlayParticles" parameter in the Animator
        animator.SetTrigger("PlayParticles");
    }
}
