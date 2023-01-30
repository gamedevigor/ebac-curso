using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyerHelper : MonoBehaviour
{
    public EnemyBase enemyBase;

    public void KillEnemy()
    {
        enemyBase.DestroyEnemy();
    }
}
