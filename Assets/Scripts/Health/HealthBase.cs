using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;
    public int startLife = 10;
    public bool destroyOnKill = false;
    private int _currentLife;
    private bool _isDead = false;
    public float delayToKill = 0f;

    [SerializeField] private FlashColor _flashColor;
    private void Awake()
    {
        Init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }
    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }
    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
        if(_flashColor != null)
        {
            _flashColor.Flash();
        }
    }
    private void Kill()
    {
        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        OnKill?.Invoke();
    }
}
