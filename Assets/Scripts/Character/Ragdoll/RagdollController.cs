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
        ToggleRagdoll(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleRagdoll(!isEnable);
        }
    }

    public void ToggleRagdoll(bool active)
    {
        isEnable = active;
        for (int i = 0; i < limbsColliders.Length; i++)
        {
            limbsColliders[i].enabled = active;
        }

        for (int i = 0; i < limbsRigidbodies.Length; i++)
        {
            limbsRigidbodies[i].isKinematic = !active;
        }

        characterCollider.isKinematic = active;
        characterRigidbody.enabled = !active;
        characterAnimator.enabled = !active;
    }

}
