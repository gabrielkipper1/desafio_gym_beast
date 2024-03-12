using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopSpot : ShopSpot
{
    [SerializeField]
    private GameObject shopUIPrefab;

    [SerializeField]
    private ItemShop itemShop;

    protected override IEnumerator onTimerEnded()
    {
        GameObject shopUI = Instantiate(shopUIPrefab);
        ItemShopUI shopUIComponent = shopUI.GetComponent<ItemShopUI>();
        shopUIComponent.OpenShop(itemShop, characterController);
        StopCoroutine(timerRoutine);
        yield break;
    }
}
