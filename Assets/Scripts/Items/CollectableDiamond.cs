using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDiamond : CollectableBase
{
    public string collectItem = "CollectDiamond";

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.Instance.AddItemDiamond();
    }
}
