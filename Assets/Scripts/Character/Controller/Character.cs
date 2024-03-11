using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private new Rigidbody rigidbody;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private new CapsuleCollider collider;

    [SerializeField]
    protected CharacterAnimatorController animatorController;

    [SerializeField]
    protected RagdollController ragdollController;

    public void Initialize()
    {
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        if (collider == null)
        {
            collider = GetComponent<CapsuleCollider>();
        }

        if (ragdollController == null)
        {
            ragdollController = GetComponent<RagdollController>();
        }

        this.animatorController = new CharacterAnimatorController(this, animator);
    }

    public void Move(Vector3 direction)
    {
        rigidbody.MovePosition(rigidbody.position + (direction.normalized * Time.fixedDeltaTime * speed));
    }

    public void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Vector3 facePoint = transform.position + direction.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(facePoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 180 * Time.deltaTime);
        }
    }

    public virtual void TakeHit(Character other)
    {
        ragdollController.EnableRagdoll(other, 600);
    }

    public virtual void HitOtherPlayer(Character character)
    {
        animatorController.Attack();
        character.TakeHit(this);
    }

    public abstract Vector2 getMovementDirection();
}
