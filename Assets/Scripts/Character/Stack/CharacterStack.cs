using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStack : MonoBehaviour
{
    public IAnimation removeFromStackAnimation;
    public IAnimation addToStackAnimation;

    public Transform stackRoot;
    public List<Transform> stack;

    public int StackCount => stack.Count;

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
        if (stackableObject.pickedUp)
        {
            return;
        }

        Vector3 position = getPreviousStackPosition(stack.Count) + stackableObject.offset;
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

    private void updatePositions()
    {
        for (int i = 0; i < stack.Count; i++)
        {
            stack[i].position = getPreviousStackPosition(i) + stack[i].GetComponent<StackableObject>().offset;
            stack[i].rotation = stackRoot.rotation;
        }
    }

    private Vector3 getPreviousStackPosition(int index)
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
