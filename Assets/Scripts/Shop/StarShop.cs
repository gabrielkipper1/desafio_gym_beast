using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StarShop", menuName = "Shop/StarShop")]
public class StarShop : StackBasedShop
{
    protected override void ApplyEffect(CharacterController buyer)
    {
        buyer.AddStars(1);
    }
}
