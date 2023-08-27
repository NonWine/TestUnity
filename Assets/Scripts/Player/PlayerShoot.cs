using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerShoot : IShoot
{
    private SphereFactory _factory;
    private CamConfig _camConfig;
    private float timer;
    private float _valueMulty;
    public event Action<float> OnShoot;

    public PlayerShoot(SphereFactory sphereFactory,CamConfig  camConfig,float valueMulty)
    {
        _factory = sphereFactory;
        _valueMulty = valueMulty;
        _camConfig = camConfig;
    }

    public void Shoot(Transform playerTransform)
    {
        if (Input.GetMouseButtonUp(0))
        {
            var sphere  = _factory.Create();
            Vector3 targetPos = _camConfig.MousePos;
            targetPos.y = playerTransform.position.y;
            sphere.transform.position = playerTransform.position;
            sphere.transform.DOScale(sphere.transform.localScale + CalculateScale(), 0.8f);
            sphere.GetComponent<Rigidbody>().velocity = (targetPos - playerTransform.position).normalized * 35f;
            timer = 0f;
        }

        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
        }

    }

    private Vector3 CalculateScale()
    {
        float scale = timer * _valueMulty;
        OnShoot(scale);
        scale *= 1.5f;
        return new Vector3(scale, scale, scale);
    }
}