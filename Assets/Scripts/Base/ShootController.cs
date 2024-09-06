using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : ObjectPool<Bullet>
{
    [SerializeField] protected float _bulletPower;
    [SerializeField] protected List<Transform> _shootPoints = new List<Transform>(); 
    
    private int _shootCount;

    public void Shoot()
    {
        if (!CheckPrefab()) return;
        
        if (_shootCount >= _shootPoints.Count)
            _shootCount = 0;
        
        var pooledObject = GetFromPool();
        pooledObject.transform.position = _shootPoints?[_shootCount].position ?? transform.position;
        
        _poolDictionary[pooledObject].Shoot(transform.up, _bulletPower);
        _shootCount++;
    }
    
}

public interface IObjectPool<T> where T : IPolledObject
{
    void ReturnToPool(T poolObject);
    T GetFromPool();
}

public interface IPolledObject
{
    void ReturnToPool();
    void Initialize(IObjectPool<PooledObject> pool);
}
