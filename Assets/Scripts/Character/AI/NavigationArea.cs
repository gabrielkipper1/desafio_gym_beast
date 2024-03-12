using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NavigationArea : MonoBehaviour
{
    public BoxCollider navigationArea;

    void Start()
    {
        if (navigationArea == null)
        {
            navigationArea = GetComponent<BoxCollider>();
        }
    }

    public Vector3 GetRandomPoint()
    {
        float x = Random.Range(navigationArea.bounds.min.x, navigationArea.bounds.max.x);
        float z = Random.Range(navigationArea.bounds.min.z, navigationArea.bounds.max.z);
        return new Vector3(x, 0, z);
    }

    // void OnDrawGizmos()
    // {
    //     if (navigationArea == null)
    //     {
    //         navigationArea = GetComponent<BoxCollider>();
    //     }

    //     Gizmos.color = Color.green;
    //     Gizmos.DrawWireCube(navigationArea.center, navigationArea.bounds.size);
    // }
}
