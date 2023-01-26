using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform StartPoint;

    private GameObject _currentPlayer;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = StartPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
    }
}
