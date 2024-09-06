using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour, IPolledObject
{
    private IObjectPool<PooledObject> _pool;

    public void Initialize(IObjectPool<PooledObject> pool)
    {
        _pool = pool;
    }

    public void ReturnToPool()
    {
        _pool.ReturnToPool(this);
    }
}
