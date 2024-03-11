using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseStackShop", menuName = "Shop/IncreaseStackShop")]
public class IncreaseStackShop : StarBasedShop
{
    protected override void ApplyEffect(CharacterController buyer)
    {
        Debug.Log("Applying effect, increasing stack");
        buyer.IncreaseStack(1);
    }
}