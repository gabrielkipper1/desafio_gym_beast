using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : Character
{
    public CharacterInput input;
    public CharacterAnimatorController animatorController;
    public CharacterStack stack;

    void Start()
    {
        this.input = new KeyboardInput();
        base.Initialize();
    }

    void Update()
    {
        animatorController.Animate();
    }

    void FixedUpdate()
    {
        handleMovement();
    }

    void handleMovement()
    {
        Vector3 movementDirection = new Vector3(input.movementInput().x, 0, input.movementInput().y);
        Move(movementDirection);
        Rotate(movementDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected");
        StackableObject stackable = other.gameObject.GetComponent<StackableObject>();
        if (stackable != null)
        {
            Debug.Log("Stackable object collided");
            stack.AddToStack(stackable);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        StackableObject stackable = collision.gameObject.GetComponent<StackableObject>();
        if (stackable != null)
        {
            Debug.Log("Stackable object collided");
            stack.AddToStack(stackable);
        }
    }

    public override Vector2 getMovementDirection()
    {
        return input.movementInput();
    }


}
