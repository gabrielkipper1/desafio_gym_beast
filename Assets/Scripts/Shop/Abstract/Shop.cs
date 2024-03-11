using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shop : ScriptableObject
{
    public int level;
    public float costMultiplier;
    public float initialCost;
    public int initialReward;
    public float rewardMultiplier;
    public int amountPaid;

    public abstract int GetLevelCost();
    public abstract void Pay(CharacterController buyer);
    protected abstract void Buy(CharacterController buyer);
    protected abstract void ApplyEffect(CharacterController buyer);
}