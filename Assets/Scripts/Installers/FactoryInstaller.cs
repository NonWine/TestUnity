using UnityEngine;
using Zenject;

public class FactoryInstaller : MonoInstaller
{
    [SerializeField] private SphereBullet sphereBullet;
    [SerializeField] private Enemy enemy;
    [SerializeField] private EnemyArea enemyArea;
    public override void InstallBindings()
    {
        FactorySphereBinding();
        FactoryEnemyBinding();
        EnemyAreaFactory();
        
    }

    private void EnemyAreaFactory()
    {
        Container.BindInstance(enemyArea).AsSingle().NonLazy();
        Container.Bind<EnemyAreaFactory>().AsSingle().NonLazy();
    }

    private void FactorySphereBinding()
    {
        Container.BindInstance(sphereBullet).AsSingle().NonLazy();
        Container.Bind<SphereFactory>().AsSingle().NonLazy();
        
    }
    
    private void FactoryEnemyBinding()
    {
        Container.BindInstance(enemy).AsSingle().NonLazy();
        Container.Bind<EnemyFactory>().AsSingle().NonLazy();
        
    }
}