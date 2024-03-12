using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ChangeColorItem", menuName = "Shop/ChangeColorItem")]
public class ChangeColorItem : ShoppableItem
{
    public Material material;

    public override void Buy(CharacterController buyer)
    {
        if (buyer.status.stars >= itemPrice)
        {
            buyer.AddStars(-itemPrice);
            isPurchased = true;
            OnItemPurchased.Invoke(this);
        }
    }

    public override void Equip(CharacterController character)
    {
        character.SetMaterial(material);
    }
}
