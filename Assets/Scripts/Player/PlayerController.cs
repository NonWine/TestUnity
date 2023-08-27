using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject] private IShoot playerShoot;
    private bool _canShoot = true;
    
    private void Update()
    {
        if(_canShoot)
        playerShoot.Shoot(transform);    
    }

    public void SetCanSoot(bool flag) => _canShoot = flag;

}