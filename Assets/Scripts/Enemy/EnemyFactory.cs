using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private DiContainer _diContainer;
    private Enemy _enemy;

    [Inject]
    public EnemyFactory(DiContainer diContainer, Enemy enemy)
    {
        _enemy = enemy;
        _diContainer = diContainer;
    }

    public Enemy Create(Vector3 position, Quaternion rotation, Transform parent)
    {
        var enemy = _diContainer.InstantiatePrefabForComponent<Enemy>(_enemy, position, rotation,parent);
        return enemy;
    }
}