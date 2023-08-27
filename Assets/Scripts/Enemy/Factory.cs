using UnityEngine;
using Zenject;

public class Factory<T> where T : MonoBehaviour
{
    private DiContainer _diContainer;
    private T _enemyArea;

    [Inject]
    public Factory(DiContainer diContainer, T enemyArea)
    {
        _enemyArea = enemyArea;
        _diContainer = diContainer;
    }

    public T Create()
    {
        var enemyArea = _diContainer.InstantiatePrefabForComponent<T>(_enemyArea);
        return enemyArea;
    }
}