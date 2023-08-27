using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using System;
using Random = UnityEngine.Random;

public class EnemyArea : MonoBehaviour
{
    [SerializeField] private Transform[] _enemyPoints;
    [SerializeField] private int _enemyCount;
    private int count;
    [Inject]
    private EnemyFactory _enemyFactory;
    public event Action OnAllEnemyDestroyed;

    private void Start()
    {
        count = _enemyCount;
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            var enemy = _enemyFactory.Create(_enemyPoints[Random.Range(0, _enemyPoints.Length)].position,Quaternion.Euler(0f, 180f, 0f),transform);
            enemy.OnDeath += CheckDeathArea;
        }
        
    }

    private void CheckDeathArea()
    {
        count--;
        if (count <= 0)
        { 
            OnAllEnemyDestroyed?.Invoke();
        }
    }
    
}