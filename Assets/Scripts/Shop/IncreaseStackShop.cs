using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseStackShop", menuName = "Shop/IncreaseStackShop")]
public class IncreaseStackShop : Shop
{
    protected override void ApplyEffect(Character buyer)
    {
        CharacterController characterController = buyer.GetComponent<CharacterController>();
        characterController.IncreaseStack(1);
    }

    public override int GetLevelCost()
    {
        return (int)(initialCost + (costMultiplier * level * 1.5f));
    }
}