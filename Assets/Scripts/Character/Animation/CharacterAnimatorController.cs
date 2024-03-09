using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    public Character character;
    public Animator animator;

    public void Animate()
    {
        animator.SetFloat("movement", character.getMovementDirection().sqrMagnitude);
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
    }
}
