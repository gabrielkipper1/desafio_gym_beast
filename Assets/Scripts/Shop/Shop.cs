using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shop : ScriptableObject
{
    public int level;
    public int cost;
    public int amountPaid;
    public float initialCost;
    public float costMultiplier;

    public virtual int GetLevelCost()
    {
        return (int)(initialCost + (costMultiplier * level));
    }

    public virtual void PayAmount(int amount, Character buyer)
    {
        amountPaid += amount;

        if (amountPaid >= GetLevelCost())
        {
            Buy(buyer);
        }
    }

    protected virtual void Buy(Character buyer)
    {
        if (amountPaid >= GetLevelCost())
        {
            amountPaid -= GetLevelCost();
            level++;
            ApplyEffect(buyer);
        }
    }

    protected abstract void ApplyEffect(Character buyer);
}