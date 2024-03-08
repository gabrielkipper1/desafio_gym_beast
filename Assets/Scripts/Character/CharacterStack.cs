using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStack : MonoBehaviour
{
    public Transform stackRoot;
    public List<Transform> stack;

    private void Start()
    {
        stack = new List<Transform>();
    }

    private void Update()
    {
        updatePositions();
    }

    public void AddToStack(StackableObject stackableObject)
    {
        Vector3 position = getPreviousStackPosition(stack.Count) + stackableObject.offset;
        stack.Add(stackableObject.transform);
        stackableObject.transform.position = position;
    }

    public void updatePositions()
    {
        for (int i = 0; i < stack.Count; i++)
        {
            stack[i].position = getPreviousStackPosition(i) + stack[i].GetComponent<StackableObject>().offset;
            stack[i].rotation = stackRoot.rotation;
        }
    }

    public Vector3 getPreviousStackPosition(int index)
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

    public void RemoveFromStack(StackableObject stackableObject)
    {
        stack.Remove(stackableObject.transform);
    }
}
