using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour, IEffect
{
    public GameObject particleEffect;

    public void Execute()
    {
        Instantiate(particleEffect, transform.position, Quaternion.identity);
    }
}
