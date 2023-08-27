using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CamConfig : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private float _speed;
    [Inject]
    private PlayerController _player;
    
    private Vector3 worldPosition;
    
    public Vector3 MousePos => worldPosition;
    
    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + _startPos,
            Time.deltaTime * _speed);
        Vector3 screenPoint = Input.mousePosition;
        Ray ray = Camera.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            worldPosition = hit.point;
        }
    }
}
