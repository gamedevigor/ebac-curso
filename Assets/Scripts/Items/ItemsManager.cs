using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EBAC.Core.Singleton;

public class ItemsManager : Singleton<ItemsManager>
{

    public SOInt coin;
    public SOInt diamond;
    public TextMeshProUGUI uiTextCoin;
    public TextMeshProUGUI uiTextDiamond;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coin.value = 0;
        diamond.value = 0;
    }

    public void AddItemCoin(int amount = 1)
    {
        coin.value += amount;
    }

    public void AddItemDiamond(int amount = 1)
    {
        diamond.value += amount;
    }
}
