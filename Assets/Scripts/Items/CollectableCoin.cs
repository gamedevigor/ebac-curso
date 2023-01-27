using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : CollectableBase
{
    public string collectItem = "CollectCoin";

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.Instance.AddCoins();
    }
}
