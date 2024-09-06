using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EngineController), typeof(PooledObject))]
public class Enemy : MonoBehaviour
{
    private EngineController _engineController;
    private PooledObject _pooledObject;

    private void Awake()
    {
        _engineController = GetComponent<EngineController>();
        _pooledObject = GetComponent<PooledObject>();
        GameCore.AddEnemy(_pooledObject);
    }

    public void StartMove(Vector2 direction)
    {
        _engineController.AddForce(direction);
    }
}
