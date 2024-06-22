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

    public void Shooting()
    {
        animator.SetTrigger("Shooting");
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
}
