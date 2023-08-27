using System;
using UnityEngine;

public class SphereBullet : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion;
    [SerializeField] private float _powerIncreaser;
    private bool trig;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            ParticlePool.Instance.PlayShoot(transform.position);
            Explose();
            other.transform.GetComponent<Enemy>().Death();
            Destroy(gameObject);
        }
    }
    

    private void Start()
    {
        Destroy(gameObject,3f);
    }

    private void Explose()
    {
        if (!trig)
        {
            trig = true;
            _radiusExplosion += ((transform.localScale.x) * _powerIncreaser);
            Collider[] enemies = Physics.OverlapSphere(transform.position, _radiusExplosion);
            foreach (var item in enemies)
            {
                if (item.CompareTag("Enemy")) 
                { 
                    item.transform.GetComponent<Enemy>().Death();
                }
            }
        }
    }
}
    
