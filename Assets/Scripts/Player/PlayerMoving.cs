using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsToEndLevel;
    private EnemySpawner _enemySpawner;
    private PlayerController _playerController;
    private Door _door;
    private int _currentPoint;
    [Inject]
    private void Construct(EnemySpawner spawner, Door door)
    {
        _enemySpawner = spawner;
        _door = door;
    }
    
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _enemySpawner.OnDeathArea += MoveNext;
    }

    private void OnDestroy()
    {
        _enemySpawner.OnDeathArea -= MoveNext;
    }

    private void Start()
    {
        transform.position = _pointsToEndLevel[_currentPoint].position;
    }

    private void MoveNext()
    {
        _playerController.SetCanSoot(false);
        _currentPoint++;
        if (_currentPoint == _pointsToEndLevel.Length)
        {
            _door.OpenedDoor(transform);
        }
        else
        {
           Sequence jump = DOTween.Sequence()
                .Append(transform.DOMoveY(2f, 0.5f))
                .Append(transform.DOMoveY(0.4f,0.5f)).SetLoops(-1);
           
                transform.DOMoveZ(_pointsToEndLevel[_currentPoint].position.z, 3f)
                    .OnComplete(()=> {jump.Kill(); _playerController.SetCanSoot(true);});
        }
    }
}
