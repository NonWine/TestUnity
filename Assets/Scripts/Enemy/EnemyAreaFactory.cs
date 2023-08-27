using UnityEngine;
using Zenject;

public class EnemyAreaFactory 
{
    private DiContainer _diContainer;
    private EnemyArea _enemyArea;
    
    [Inject]
    public EnemyAreaFactory(DiContainer diContainer, EnemyArea enemyArea)
    {
        _enemyArea = enemyArea;
        _diContainer = diContainer;
    }

    public EnemyArea Create(Transform parent)
    {
        var enemyArea = _diContainer.InstantiatePrefabForComponent<EnemyArea>(_enemyArea,parent);
        return enemyArea;
    }
}
