using Zenject;

public class SphereFactory
{
    private SphereBullet _sphereBullet;
    private DiContainer _diContainer;
    public SphereFactory(SphereBullet sphereBullet, DiContainer diContainer)
    {
        _sphereBullet = sphereBullet;
        _diContainer = diContainer;
    }

    public SphereBullet Create()
    {
        var bullet = _diContainer.InstantiatePrefabForComponent<SphereBullet>(_sphereBullet);
        return bullet;
    }
    
}