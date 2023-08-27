using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [Inject] private EnemyAreaFactory enemyAreaFactory;
    private int currentIndex;
    public event Action OnDeathArea;
    
    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        var area = enemyAreaFactory.Create(transform);
            area.transform.position = _points[currentIndex].position;
            area.SpawnEnemies();
            area.OnAllEnemyDestroyed += CheckDestroyedArea;
        ParticlePool.Instance.PlayPoof(area.transform.position + Vector3.up);
    }

    private void CheckDestroyedArea()
    {
            currentIndex++;
        if (currentIndex < _points.Length)
        {
            Spawn();
        }
        OnDeathArea?.Invoke();
    }
}
