using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EngineController : MonoBehaviour
{
    [SerializeField] protected float _enginePower;
    [SerializeField] protected ForceMode2D _forceMode;
    protected Rigidbody2D _rigidbody2D;

    protected void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public virtual void AddForce(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * (_enginePower), _forceMode);
    }

    public virtual void AddForce()
    {
        AddForce(transform.up);
    }
    
    
}
