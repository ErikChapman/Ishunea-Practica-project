using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour, IObjectPool<PooledObject> where T : MonoBehaviour
{
    [SerializeField] protected PooledObject _prefab;
    [SerializeField] protected int _objectsInPoolCount = 5;

    protected Queue<PooledObject> _pool;
    protected Dictionary<PooledObject, T> _poolDictionary;

    private void Awake()
    {
        if (!CheckPrefab())
            return;
        
        _pool = new Queue<PooledObject>();
        _poolDictionary = new Dictionary<PooledObject, T>();

        for (int i = 0; i < _objectsInPoolCount; i++)
            InstantiatePrefab();
    }

    public virtual void ReturnToPool(PooledObject poolObject)
    {
        poolObject.gameObject.transform.position = transform.position;
        poolObject.gameObject.transform.parent = transform;

        poolObject.gameObject.SetActive(false);

        _pool.Enqueue(poolObject);
    }

    public virtual PooledObject GetFromPool()
    {    
        if (_pool.Count <= 0)
            InstantiatePrefab();
        
        var bullet = _pool.Dequeue();
        bullet.transform.parent = null;
        bullet.gameObject.SetActive(true);
        bullet.transform.localRotation = transform.rotation;
        return bullet;
    }

    private PooledObject InstantiatePrefab()
    {
        var pooledObject = Instantiate(_prefab, transform.position, Quaternion.identity);
        var tComponent = pooledObject.GetComponent<T>();
        pooledObject.transform.position = transform.position;
        pooledObject.transform.parent = transform;

        pooledObject.gameObject.SetActive(false);
        pooledObject.Initialize(this);

        _poolDictionary.Add(pooledObject, tComponent);
        _pool.Enqueue(pooledObject);

        return pooledObject;
    }

    protected bool CheckPrefab()
    {
        if (_prefab != null)
            return true;
        
        Debug.LogWarning("Bullet is not found!");
        return false;
    }
}
