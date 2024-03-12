using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopUI : MonoBehaviour
{
    public GameObject itemButtonPrefab;
    public Transform listContentRoot;


    public void OpenShop(ItemShop shop, CharacterController character)
    {
        for (int i = 0; i < shop.items.Count; i++)
        {
            GameObject itemButton = Instantiate(itemButtonPrefab, listContentRoot);
            ShopItemList itemButtonUI = itemButton.GetComponent<ShopItemList>();
            itemButtonUI.SetItem(character, shop.items[i]);
        }
    }

    public void CloseUI()
    {
        Destroy(gameObject);
    }
}
