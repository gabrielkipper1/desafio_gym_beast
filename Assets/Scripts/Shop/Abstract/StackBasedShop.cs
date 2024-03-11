using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StackBasedShop : Shop
{
    public override int GetLevelCost()
    {
        return (int)(initialCost + (costMultiplier * level));
    }

    public override void Pay(CharacterController buyer)
    {
        int amountLeft = GetLevelCost() - amountPaid;
        int amountToPay = Math.Min(buyer.status.stackedAmount, amountLeft);

        if(amountToPay > 0){
            amountPaid += amountToPay;
            buyer.RemoveFromStack(amountToPay);
            Debug.Log("Paying stacks, amount paid: " + amountPaid);
        }

        if (amountPaid >= GetLevelCost())
        {
            Debug.Log("Buying from stacks");
            Buy(buyer);
        }
    }

    protected override void Buy(CharacterController buyer)
    {
        Debug.Log("Buying stacks");
        amountPaid -= GetLevelCost();
        level++;
        ApplyEffect(buyer);
    }
}
