using System;
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

        if (amountToPay > 0)
        {
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
}
