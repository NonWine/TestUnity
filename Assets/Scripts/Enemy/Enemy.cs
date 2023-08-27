using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Color32 _deathColor;
    [SerializeField] private SkinnedMeshRenderer material;
    private bool trig;
    public event Action OnDeath;
    
    public void Death()
    {
        if (!trig)
        {
            GetComponent<BoxCollider>().enabled = false;
            trig = true;
            material.material.DOColor(_deathColor, 1f);
            Invoke(nameof(Dead),1.5f);
        }
    }

    private void Dead()
    {
        OnDeath?.Invoke();
        ParticlePool.Instance.PlayExplosion(transform.position);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnDeath = null;
    }
}