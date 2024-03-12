using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopSpot : MonoBehaviour
{
    protected Coroutine timerRoutine;
    protected CharacterController characterController;
    protected float timeLeft;

    [SerializeField]
    protected Shop shop;

    [SerializeField]
    private float timer;

    [SerializeField]
    protected float timeBetweenIteractions;

    public CharacterController playerIn => characterController;
    public bool isPlayerIn => characterController != null;
    public float percentage => timeLeft / timer;

    protected abstract IEnumerator onTimerEnded();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCounter();
            characterController = other.gameObject.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndCounter();
            characterController = null;
        }
    }

    void StartCounter()
    {
        timerRoutine = StartCoroutine("Counter");
    }

    void EndCounter()
    {
        StopCoroutine(timerRoutine);
    }

    IEnumerator Counter()
    {
        timeLeft = timer;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        while (playerIn != null)
        {
            // shop.Pay(controller);
            yield return onTimerEnded();
        }
    }
}
