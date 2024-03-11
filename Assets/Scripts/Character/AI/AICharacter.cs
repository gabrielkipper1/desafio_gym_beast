using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Events;

public class AICharacter : Character
{
    public GameObject stackableReplacement;
    public NavMeshAgent agent;
    public Transform target;

    private void Start()
    {
        base.Initialize();
        agent.SetDestination(target.position);
    }

    public void Update()
    {
        animatorController.Animate();
    }

    public override Vector2 getMovementDirection()
    {
        return new Vector2(agent.velocity.x, agent.velocity.z);
    }

    public override void TakeHit(Character other)
    {
        agent.enabled = false;
        base.TakeHit(other);
        InstantiateStackableObject(other);
    }

    private void InstantiateStackableObject(Character other)
    {
        CharacterController characterController = other.transform.GetComponent<CharacterController>();
        if (characterController == null)
        {
            return;
        }

        GameObject stackable = Instantiate(stackableReplacement, transform.position, Quaternion.identity);
        StackableObject stackableBehaviour = stackable.GetComponent<StackableObject>();
        characterController.StackObject(stackableBehaviour);

    }
}
