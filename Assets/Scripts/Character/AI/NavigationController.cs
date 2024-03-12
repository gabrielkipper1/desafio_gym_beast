using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public List<NavigationArea> areas = new List<NavigationArea>();

    void Start()
    {
        areas.AddRange(FindObjectsByType<NavigationArea>(sortMode: FindObjectsSortMode.None));
    }

    public Vector3 GetRandomPoint()
    {
        if (areas.Count == 0)
        {
            return Vector3.zero;
        }

        int randomIndex = Random.Range(0, areas.Count);
        return areas[randomIndex].GetRandomPoint();
    }
}
