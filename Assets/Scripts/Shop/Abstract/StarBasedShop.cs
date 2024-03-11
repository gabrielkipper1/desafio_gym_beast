using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StarBasedShop : Shop
{
    public override int GetLevelCost()
    {
        return (int)(initialCost + (costMultiplier * level));
    }

    public override void Pay(CharacterController buyer)
    {
        int amountLeft = GetLevelCost() - amountPaid;
        int amountToPay = Mathf.Min(buyer.status.stars, amountLeft);
        amountPaid += amountToPay;
        
        if (amountPaid >= GetLevelCost())
        {
            buyer.AddStars(-amountPaid);
            Buy(buyer);
        }
    }

    protected override void Buy(CharacterController buyer)
    {
        amountPaid -= GetLevelCost();
        level++;
        ApplyEffect(buyer);
    }
}
