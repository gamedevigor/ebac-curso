using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EBAC.Core.Singleton;

public class ItemsManager : Singleton<ItemsManager>
{

    public int coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextCoins.text = coins.ToString();
    }
}
