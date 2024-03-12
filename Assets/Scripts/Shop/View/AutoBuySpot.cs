using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBuySpot : ShopSpot
{
    protected override IEnumerator onTimerEnded()
    {
        shop.Pay(characterController);
        yield return new WaitForSeconds(timeBetweenIteractions);
    }

}
