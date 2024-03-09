using UnityEngine;
using System.Collections;

public class Animations
{
    public static void AnimatePositionAndScale(GameObject gameObject, Vector3 position, Vector3 scale, float time, bool autoStart = true)
    {
        PositionAndScaleAnimation animation = gameObject.AddComponent<PositionAndScaleAnimation>();
        animation.SetParameters(position, scale, time);

        if (autoStart)
        {
            animation.Animate();
        }
    }
}
