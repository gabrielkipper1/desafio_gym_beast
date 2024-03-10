using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStack : MonoBehaviour
{
    public UnityEvent<int> OnStackUpdated = new UnityEvent<int>();
    public IAnimation removeFromStackAnimation;
    public IAnimation addToStackAnimation;

    public Transform stackRoot;
    public List<Transform> stack;

    public int maxStackCount;
    public int StackCount => stack.Count;

    private void Start()
    {
        stack = new List<Transform>();
    }

    private void Update()
    {
        UpdatePositions();
    }

    public void IncreaseStack(int amount)
    {
        maxStackCount += amount;
    }

    public void AddToStack(StackableObject stackableObject)
    {
        if (stackableObject.pickedUp || stack.Count >= maxStackCount)
        {
            return;
        }

        Vector3 position = GetPreviousStackPosition(stack.Count) + stackableObject.offset;
        stack.Add(stackableObject.transform);
        stackableObject.transform.position = position;
        stackableObject.pickedUp = true;
    }

    public void RemoveFromStack()
    {
        if (stack.Count > 0)
        {
            Transform stackTransform = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            Animations.AnimatePositionAndScale(stackTransform.gameObject, new Vector3(transform.position.x, -1, transform.position.z), Vector3.zero, 0.5f);
        }
    }

    private void UpdatePositions()
    {
        for (int i = 0; i < stack.Count; i++)
        {
            stack[i].position = GetPreviousStackPosition(i) + stack[i].GetComponent<StackableObject>().offset;
            stack[i].rotation = stackRoot.rotation;
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
