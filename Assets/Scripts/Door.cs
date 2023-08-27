using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _leftDoor;
    [SerializeField] private Transform _rightDoor;
    
    public void OpenedDoor(Transform target)
    {
        _leftDoor.DORotate(new Vector3(0, -270f, 0f), 3f);
        _rightDoor.DORotate(new Vector3(0f, 90f, 0f), 3f).
            OnComplete(() => { target.DOMove(transform.position + Vector3.up, 1.5f).
                OnComplete(() => {GameManager.Instance.GameWin();}); });

    }
}
