using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMarker : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _prefab;
    private void Start()
    {
        var door = Instantiate(_prefab, _point.position, Quaternion.identity);
        
    }

    private void OpenDoor()
    {
        
    }
}
