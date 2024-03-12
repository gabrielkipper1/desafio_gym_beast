using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ShoppableItem : ScriptableObject
{
    public UnityEvent<ShoppableItem> OnItemPurchased = new UnityEvent<ShoppableItem>();
    public UnityEvent<CharacterController> OnItemEquipped = new UnityEvent<CharacterController>();

    public Sprite itemSprite;
    public string itemName;
    public int itemPrice;
    public bool isPurchased;

    public abstract void Buy(CharacterController buyer);
    public abstract void Equip(CharacterController character);
}
