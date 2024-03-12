using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public GameObject destroyVFX;
    private bool isEnable;
    public Transform viewRoot;

    public Animator characterAnimator;
    public Rigidbody CharacterRigidbody;
    public CapsuleCollider CharacterCollider;

    public Collider[] limbsColliders;
    public Rigidbody[] limbsRigidbodies;

    void Start()
    {
        limbsColliders = viewRoot.GetComponentsInChildren<Collider>();
        limbsRigidbodies = viewRoot.GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    void SetDestroyTimer()
    {
        Destroy(gameObject, 5f);
        if (destroyVFX != null)
        {
            GameObject vfx = Instantiate(destroyVFX, transform.position, Quaternion.identity);
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

        CharacterRigidbody.isKinematic = false;
        CharacterCollider.enabled = true;
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
            limbsRigidbodies[i].drag = 1;
            limbsRigidbodies[i].angularDrag = 2f;
            Vector3 inverseDirection = (limbsRigidbodies[i].transform.position - puncher.transform.position).normalized;
            limbsRigidbodies[i].velocity = new Vector3(inverseDirection.x * force, force * 0.3f, inverseDirection.z * force);
        }

        CharacterRigidbody.isKinematic = true;
        CharacterCollider.enabled = false;
        characterAnimator.enabled = false;
        SetDestroyTimer();
    }

}
