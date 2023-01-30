using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;

    public void KillPlayer()
    {
        player.DestroyMe();
    }
}
