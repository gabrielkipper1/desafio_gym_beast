using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Events;

public class AICharacter : Character
{
    private NavigationController navigationController;
    public GameObject stackableReplacement;
    public NavMeshAgent agent;
    public Transform target;

    public int minWalkTime = 2;
    public int maxWalkTime = 10;
    public int walkingTime;

    private Coroutine walkCoroutine;

    private void Start()
    {
        navigationController = FindFirstObjectByType<NavigationController>();
        base.Initialize();
        walkCoroutine = StartCoroutine(WalkBehaviour());
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
        StopCoroutine(walkCoroutine);
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

    private IEnumerator WalkBehaviour()
    {
        while (true)
        {
            agent.SetDestination(navigationController.GetRandomPoint());
            yield return new WaitForSeconds(Random.Range(minWalkTime, maxWalkTime));
        }
    }
}
