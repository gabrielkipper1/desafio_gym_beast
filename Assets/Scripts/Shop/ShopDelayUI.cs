using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopDelayUI : MonoBehaviour
{
    public Image progressImage;
    public ShopSpot shop;

    void Update()
    {
        if (shop.isPlayerIn)
        {
            progressImage.fillAmount = shop.percentage;
        }
        else
        {
            progressImage.fillAmount = 0;
        }
    }


}
