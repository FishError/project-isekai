using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public void FlipLocalScaleX(float x)
    {
        transform.localScale = new Vector3(x * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    public void SetAnimatorBoolToTrue(string name)
    {
        animator.SetBool(name, true);
    }

    public void SetAnimatorBoolToFalse(string name)
    {
        animator.SetBool(name, false);
    }
}
