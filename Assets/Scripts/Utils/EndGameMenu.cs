using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    public string playerTag = "Player";
    public GameObject endScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(playerTag))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        endScreen.SetActive(true);
    }
}