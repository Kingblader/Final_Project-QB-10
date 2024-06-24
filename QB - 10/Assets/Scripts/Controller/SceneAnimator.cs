using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAnimator : MonoBehaviour
{
    private Animator animator;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator = target.GetComponent<Animator>();

    }

    public void StartWalking()
    {
        animator.SetTrigger("StartWalking");
    }

    public void Transform()
    {
        animator.SetTrigger("Transform");
    }

    public void DrawWeapon()
    {
        animator.SetTrigger("DrawWeapon");
    }

    public void HolsterWeapon()
    {
        animator.SetTrigger("HolsterWeapon");
    }

    public void Shooting()
    {
        animator.SetTrigger("Shooting");
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Reload()
    {
        animator.SetTrigger("Reload");
    }

    public void TransformBack()
    {
        animator.SetTrigger("TransformBack");
    }

    public void Idle()
    {
        animator.SetTrigger("Idle");
    }

    public void Transformed()
    {
        animator.SetTrigger("Transformed");
    }

    public void Death()
    {
        animator.SetTrigger("Die");
    }
}
