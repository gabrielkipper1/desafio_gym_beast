using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : IEffect
{
    public AudioClip audioEffect;

    public void Execute()
    {
        AudioSource.PlayClipAtPoint(audioEffect, Camera.main.transform.position);
    }
}
