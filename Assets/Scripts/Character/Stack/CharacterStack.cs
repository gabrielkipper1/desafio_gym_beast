using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStack
{
    public CharacterStack(CharacterController characterController, Transform stackRoot)
    {
        this.character = characterController;
        this.stackRoot = stackRoot;
        this.stack = new List<StackableObject>();

        characterController.OnStackIncreased.AddListener(AddToStack);
        characterController.OnStackDecreased.AddListener(RemoveFromStack);
    }

    private float inertialForce = 15f;
    private CharacterController character;
    public Transform stackRoot;
    public List<StackableObject> stack;

    public void Update()
    {
        UpdatePositions();
    }

    public void AddToStack(StackableObject stackableObject)
    {
        if (stackableObject.pickedUp || stack.Count >= character.status.maxStack)
        {
            Debug.Log("Stack is full");
            return;
        }

        Vector3 position = GetPreviousStackPosition(stack.Count) + stackableObject.offset;
        stackableObject.root.transform.position = position;

        stack.Add(stackableObject);
        stackableObject.MarkAsPickedUp();
    }

    public void RemoveFromStack(int amount)
    {
        int removedAmount = amount;
        while (removedAmount > 0)
        {
            if (stack.Count == 0)
            {
                return;
            }
            StackableObject removed = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            removed.DropAndDestroy();
            removedAmount--;
        }
    }

    private void UpdatePositions()
    {
        for (int i = 0; i < stack.Count; i++)
        {
            Vector3 targetPosition = GetPreviousStackPosition(i) + stack[i].offset;
            Quaternion targetRotation = stackRoot.rotation;

            stack[i].transform.SetPositionAndRotation(
                Vector3.Lerp(stack[i].root.transform.position, targetPosition, inertialForce * Time.deltaTime),
                Quaternion.Slerp(stack[i].root.transform.rotation, targetRotation, inertialForce * Time.deltaTime));
            // stack[i].transform.SetPositionAndRotation(
            //     GetPreviousStackPosition(i) + stack[i].GetComponent<StackableObject>().offset,
            //     stackRoot.rotation
            // );
        }
    }

    private Vector3 GetPreviousStackPosition(int index)
    {
        if (index > 0)
        {
            return stack[index - 1].transform.position;
        }
        else
        {
            return stackRoot.position;
        }
    }
}
