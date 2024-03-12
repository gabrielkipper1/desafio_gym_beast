using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemShop", menuName = "Shop/ItemShop")]
public class ItemShop : ScriptableObject
{
    public List<ShoppableItem> items = new List<ShoppableItem>();
    public UnityEvent<ShoppableItem> OnItemPurchased = new UnityEvent<ShoppableItem>();

    public void PurchaseItem(ShoppableItem item, CharacterController buyer)
    {
        if (item.isPurchased)
        {
            return;
        }

        if (buyer.status.stars >= item.itemPrice)
        {
            buyer.AddStars(-item.itemPrice);
            item.isPurchased = true;
            OnItemPurchased.Invoke(item);
        }
    }
}
