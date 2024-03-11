using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopDetailUi : MonoBehaviour
{
    public Shop shop;
    public TextMeshProUGUI requiredPayment;
    public TextMeshProUGUI rewardAmount;

    void Update()
    {
        requiredPayment.text = (shop.GetLevelCost() - shop.amountPaid).ToString();
        rewardAmount.text = shop.GetRewardAmount().ToString();
    }

}
