using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class PlayerScale : MonoBehaviour
{
    [Inject]
    private PlayerShoot _playerShoot;
    [SerializeField] private float _startScale;
    
    private void Awake()
    {
        _playerShoot.OnShoot += DecreaseScale;
    }

    private void OnDestroy()
    {
        _playerShoot.OnShoot -= DecreaseScale;
    }

    private void Start()
    {
        transform.localScale = new Vector3(_startScale, _startScale, _startScale);
    }

    private void DecreaseScale(float scale)
    {
        _startScale -= scale * 0.5f;
        transform.DOScale(new Vector3(_startScale, _startScale, _startScale), 0.5f);
        if (_startScale < 0.25f)
        {
            GameManager.Instance.GameLose();
        }
    }
}