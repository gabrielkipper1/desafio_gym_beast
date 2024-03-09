using UnityEngine;
using System.Collections;

public class PositionAndScaleAnimation : MonoBehaviour, IAnimation
{
    public Vector3 position;
    public Vector3 scale;
    public float time;

    public void SetParameters(Vector3 position, Vector3 scale, float time)
    {
        this.position = position;
        this.scale = scale;
        this.time = time;
    }

    public void Animate()
    {
        //animate
        StartCoroutine(animatePositionAndScale());
    }

    IEnumerator animatePositionAndScale()
    {
        Debug.Log("Iniciando animacao");
        float timer = time;
        while(timer > 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, position, 10* time * Time.deltaTime);
            gameObject.transform.localScale = Vector3.MoveTowards(gameObject.transform.lossyScale, scale, 10* time * Time.deltaTime);
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
