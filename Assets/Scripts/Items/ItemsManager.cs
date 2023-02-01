using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EBAC.Core.Singleton;

public class ItemsManager : Singleton<ItemsManager>
{

    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

}
