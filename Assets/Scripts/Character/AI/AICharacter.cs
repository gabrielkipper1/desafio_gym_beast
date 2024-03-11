using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AICharacter : Character
{
    public NavMeshAgent agent;
    public Transform target;

    [SerializeField]
    private StackableObject stackableBehaviour;

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
        base.TakeHit(other);
        StartCoroutine(SetAsPickable());
    }

    IEnumerator SetAsPickable()
    {
        yield return new WaitForSeconds(1f);
        stackableBehaviour.enabled = true;
    }

}
