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
}
