using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EngineController), typeof(PooledObject))]
public class Bullet : MonoBehaviour
{
    private EngineController _engineController;
    private Rigidbody2D _rigidbody2D;
    private PooledObject _pooledObject;

    private void Awake()
    {
        _engineController = GetComponent<EngineController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _pooledObject = GetComponent<PooledObject>();
    }
    
    public void Shoot(Vector2 direction, float power)
    {
        _rigidbody2D.velocity = Vector2.zero;
        _engineController.AddForce(direction * power);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var enemy = GameCore.GetEnemy(col.gameObject);

        if (enemy == null) return;
        
        enemy.ReturnToPool();
        _pooledObject.ReturnToPool();
    }
}
