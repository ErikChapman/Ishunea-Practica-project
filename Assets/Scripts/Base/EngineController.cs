using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EngineController : MonoBehaviour
{
    [SerializeField] protected float _enginePower;
    [SerializeField] protected ForceMode2D _forceMode;
    [SerializeField] private float _maxSpeed = 2f;  // Максимальная скорость
    protected Rigidbody2D _rigidbody2D;

    protected void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public virtual void AddForce(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * _enginePower, _forceMode);
        LimitSpeed();  // Примените ограничение скорости
    }

    public virtual void AddForce()
    {
        AddForce(transform.up);
    }

    private void LimitSpeed()
    {
        if (_rigidbody2D.velocity.magnitude > _maxSpeed)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _maxSpeed;
        }
        // Вывод текущей скорости в консоль
        Debug.Log($"Current Speed: {_rigidbody2D.velocity.magnitude}");
    }
}
