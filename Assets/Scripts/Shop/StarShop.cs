using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StarShop", menuName = "Shop/StarShop")]
public class StarShop : StackBasedShop
{
    protected override void ApplyEffect(CharacterController buyer)
    {
        Debug.Log("Applying effect, adding stars");
        buyer.AddStars(GetRewardAmount());
    }

    public override int GetRewardAmount()
    {
        return (int)(level * 1.3f);
    }
}
