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
        this.stack = new List<Transform>();

        characterController.OnStackIncreased.AddListener(AddToStack);
        characterController.OnStackDecreased.AddListener(RemoveFromStack);
        // characterController.OnMaxStrackIncreased.AddListener(IncreaseStack);
    }

    private CharacterController character;
    public Transform stackRoot;
    public List<Transform> stack;

    public void Update()
    {
        UpdatePositions();
    }

    // public void IncreaseStack(int amount)
    // {
    //     maxStackCount += amount;
    // }

    public void AddToStack(StackableObject stackableObject)
    {
        if (stackableObject.pickedUp || stack.Count >= character.status.maxStack)
        {
            Debug.Log("Stack is full");
            return;
        }
        Debug.Log("Adding to stack on character stack");

        Vector3 position = GetPreviousStackPosition(stack.Count) + stackableObject.offset;
        stack.Add(stackableObject.transform);
        stackableObject.transform.position = position;
        stackableObject.pickedUp = true;
    }

    public void RemoveFromStack(int amount)
    {
       int removedAmount = amount;
       while(removedAmount > 0){
            if(stack.Count == 0){
                return;
            }
            
            stack.RemoveAt(stack.Count - 1);
            removedAmount--;
       }
    }

    private void UpdatePositions()
    {
        for (int i = 0; i < stack.Count; i++)
        {
            stack[i].SetPositionAndRotation(GetPreviousStackPosition(i) + stack[i].GetComponent<StackableObject>().offset, stackRoot.rotation);
        }
    }

    private Vector3 GetPreviousStackPosition(int index)
    {
        if (index > 0)
        {
            return stack[index - 1].position;
        }
        else
        {
            return stackRoot.position;
        }
    }
}
