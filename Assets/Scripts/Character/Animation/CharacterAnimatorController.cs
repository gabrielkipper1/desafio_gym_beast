using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController
{
    public CharacterAnimatorController(Character character, Animator animator)
    {
        this.character = character;
        this.animator = animator;
    }
    private Character character;
    private Animator animator;

    public void Animate()
    {
        animator.SetFloat("movement", character.getMovementDirection().sqrMagnitude);
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
    }
}
