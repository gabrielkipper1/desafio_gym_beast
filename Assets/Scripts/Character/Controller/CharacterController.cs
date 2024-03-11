using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : Character
{
    //STACK EVENTS
    public UnityEvent<StackableObject> OnStackIncreased = new UnityEvent<StackableObject>();
    public UnityEvent<int>  OnStackDecreased = new UnityEvent<int>();
    public UnityEvent<int> OnStackUpdated = new UnityEvent<int>();
    public UnityEvent <int> OnMaxStrackIncreased = new UnityEvent<int>();
  
    //START EVENTS
    public UnityEvent<int> OnStarsAdded = new UnityEvent<int>();
    public UnityEvent<int> OnStarsRemoved = new UnityEvent<int>();
    public UnityEvent<int> OnStarsUpdated = new UnityEvent<int>();

    public CharacterInput input;
    public CharacterStack stack;
    public CharacterStatus status;
    public Transform stackRoot;

    void Start()
    {
        base.Initialize();
        this.input = new KeyboardInput();
        this.stack = new CharacterStack(this, this.stackRoot);
        this.status.RegisterEvents(this);
    }

    void Update()
    {
        animatorController.Animate();
        this.stack.Update();
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
        StackableObject stackable = other.gameObject.GetComponent<StackableObject>();
        if (stackable != null)
        {
            StackObject(stackable);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Character character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                this.HitOtherPlayer(character);
            }
        }
    }

    public override Vector2 getMovementDirection()
    {
        return input.movementInput();
    }

    public void StackObject(StackableObject stackableObject)
    {
        this.OnStackIncreased.Invoke(stackableObject);
        this.OnStackUpdated.Invoke(this.status.stackedAmount);
    }

    public void IncreaseStack(int amount)
    {
        this.OnMaxStrackIncreased.Invoke(amount);
        this.OnStackUpdated.Invoke(this.status.stackedAmount);
    }

    public void RemoveFromStack(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            this.OnStackDecreased.Invoke(1);
            this.OnStackUpdated.Invoke(this.status.stackedAmount);
        }
    }

    public void AddStars(int amount)
    {
        if(amount > 0){
            this.OnStarsAdded.Invoke(amount);
        }
        else if(amount < 0){
            this.OnStarsRemoved.Invoke(amount);
        }

        this.OnStarsUpdated.Invoke(this.status.stars);
    }


    void OnDisable(){
        this.status.UnregisterEvents(this);
    }
}
