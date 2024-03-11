using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopParticleEffect : MonoBehaviour
{
    [SerializeField]
    private Shop shop;

    [SerializeField]
    private List<ParticleEffect> particleEffects;

    void OnLevelUp()
    {
        for (int i = 0; i < particleEffects.Count; i++)
        {
            particleEffects[i].Execute();
        }
    }

    void OnEnable()
    {
        shop.onLevelUp.AddListener(OnLevelUp);
    }

    void OnDisable()
    {
        shop.onLevelUp.RemoveListener(OnLevelUp);
    }
}
