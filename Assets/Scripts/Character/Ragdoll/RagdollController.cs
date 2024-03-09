using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private bool isEnable;
    public Transform viewRoot;

    public Animator characterAnimator;
    public Rigidbody characterCollider;
    public CapsuleCollider characterRigidbody;

    public Collider[] limbsColliders;
    public Rigidbody[] limbsRigidbodies;

    void Start()
    {
        limbsColliders = viewRoot.GetComponentsInChildren<Collider>();
        limbsRigidbodies = viewRoot.GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //EnableRagdoll(transform.position, 10);
        }
    }

    public void DisableRagdoll()
    {
        isEnable = true;
        for (int i = 0; i < limbsColliders.Length; i++)
        {
            limbsColliders[i].enabled = false;
        }

        for (int i = 0; i < limbsRigidbodies.Length; i++)
        {
            limbsRigidbodies[i].isKinematic = true;
        }

        characterCollider.isKinematic = false;
        characterRigidbody.enabled = true;
        characterAnimator.enabled = true;
    }

    public void EnableRagdoll(Character puncher, float force)
    {
        isEnable = true;
        for (int i = 0; i < limbsColliders.Length; i++)
        {
            limbsColliders[i].enabled = true;
        }

        for (int i = 0; i < limbsRigidbodies.Length; i++)
        {
            limbsRigidbodies[i].isKinematic = false;
            limbsRigidbodies[i].AddForce(puncher.transform.forward.normalized * force, ForceMode.Acceleration);
            limbsRigidbodies[i].collisionDetectionMode = CollisionDetectionMode.Continuous;
            limbsRigidbodies[i].sleepThreshold = 0.0f;
        }

        characterCollider.isKinematic = true;
        characterRigidbody.enabled = false;
        characterAnimator.enabled = false;
    }

}
