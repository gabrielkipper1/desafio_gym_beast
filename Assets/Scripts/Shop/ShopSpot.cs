using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpot : MonoBehaviour
{
    private Coroutine timerRoutine;
    private CharacterController controller;
    private float timeLeft;

    [SerializeField]
    private Shop shop;

    [SerializeField]
    private float timer;

    [SerializeField]
    private float timeBetweenIteractions;

    public CharacterController playerIn => controller;
    public bool isPlayerIn => controller != null;
    public float percentage => timeLeft / timer;

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

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        while (controller.stack.StackCount > 0)
        {
            shop.PayAmount(1, controller);
            controller.stack.RemoveFromStack();
            yield return new WaitForSeconds(timeBetweenIteractions);
        }
    }
}
