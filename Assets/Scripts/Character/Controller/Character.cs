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
    private new CapsuleCollider collider;


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

    public abstract Vector2 getMovementDirection();
}
