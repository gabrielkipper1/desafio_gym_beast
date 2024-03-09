using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpot : MonoBehaviour
{
    private Coroutine timerRoutine;
    private CharacterController controller;
    public float timer;
    public float timeLeft;
    public float timeBetweenIteractions;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCounter();
            controller = other.gameObject.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndCounter();
            controller = null;
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

        while(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        while(controller.stack.StackCount > 0)
        {
            controller.stack.RemoveFromStack();
            yield return new WaitForSeconds(timeBetweenIteractions);
        }
    }
}
