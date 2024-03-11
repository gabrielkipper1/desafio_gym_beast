using UnityEngine;
using UnityEngine.Events;

public abstract class Shop : ScriptableObject
{
    public UnityEvent onLevelUp;

    public int level;
    public float costMultiplier;
    public float initialCost;
    public int initialReward;
    public float rewardMultiplier;
    public int amountPaid;

    public abstract int GetLevelCost();
    public abstract int GetRewardAmount();

    public abstract void Pay(CharacterController buyer);
    protected abstract void ApplyEffect(CharacterController buyer);

    protected virtual void Buy(CharacterController buyer)
    {
        amountPaid -= GetLevelCost();
        LevelUp();
        ApplyEffect(buyer);
    }

    protected void LevelUp()
    {
        level++;
        onLevelUp.Invoke();
    }

}