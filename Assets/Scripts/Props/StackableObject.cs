using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject staticObject;
    public bool pickedUp;
    public Vector3 offset;
}
