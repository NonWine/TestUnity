using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CamConfig camConfig;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Door door;
    [SerializeField] private Transform doorPoint;
    [SerializeField] private float _multyValue;
    public override void InstallBindings()
    {
        PlayerShootBinding();
        CameraBinding();
        EnemySpawnerBinding();

       var gate =  Container.InstantiatePrefabForComponent<Door>(door,doorPoint.position,Quaternion.identity, null);
       Container.BindInstance(gate).AsSingle().NonLazy();
    }

    private void EnemySpawnerBinding()
    {
        Container.BindInstance(enemySpawner).AsSingle();
    }

    private void CameraBinding()
    {
        Container.BindInstance(camConfig).AsSingle().NonLazy();
    }


    private void PlayerShootBinding()
    {
        Container.BindInstance(playerController).AsSingle();
        Container.BindInstance(_multyValue).AsSingle().WhenInjectedInto<PlayerShoot>();
        Container.BindInterfacesAndSelfTo<PlayerShoot>().AsSingle();
    }
}