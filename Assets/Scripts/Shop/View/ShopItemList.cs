using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ShopItemList : MonoBehaviour
{
    public ShoppableItem item;
    public Image spriteRenderer;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;

    public Button buyButton;
    public Button equipButton;

    public void SetItem(CharacterController buyer, ShoppableItem item)
    {
        this.item = item;
        spriteRenderer.sprite = item.itemSprite;
        nameText.text = item.name;
        priceText.text = item.itemPrice.ToString();

        buyButton.gameObject.SetActive(!item.isPurchased && buyer.status.stars >= item.itemPrice);
        equipButton.gameObject.SetActive(item.isPurchased);

        buyButton.onClick.AddListener(() => item.Buy(buyer));
        equipButton.onClick.AddListener(() => item.Equip(buyer));
    }
}
