using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool Instance;

     [SerializeField] private ParticleSystem[] _poofFx;
     [SerializeField] private ParticleSystem[] _explosionFx;
    [SerializeField] private ParticleSystem[] _bulletFx;
    private int currentExplosion;
    private int currentPoof;
    private int currentShoot;
    
    private void Awake()
    {
        Instance = this;
    }

    public void PlayPoof(Vector3 pos)
    {
        _poofFx[currentPoof].transform.position = pos;
        _poofFx[currentPoof].Play();
        currentPoof++;
        if (currentPoof == _poofFx.Length)
            currentPoof = 0;
    }

    public void PlayExplosion(Vector3 pos)
    {
        _explosionFx[currentExplosion].transform.position = pos;
        _explosionFx[currentExplosion].Play();
        currentExplosion++;
        if (currentExplosion == _explosionFx.Length)
            currentExplosion = 0;
    }
    public void PlayShoot(Vector3 pos)
    {
        _bulletFx[currentShoot].transform.position = pos;
        _bulletFx[currentShoot].Play();
        currentShoot++;
        if (currentShoot == _bulletFx.Length)
            currentShoot = 0;
    }

}
