using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool<Enemy>
{
    [SerializeField] private float _spawnRadius = 20;
    
    [SerializeField] private ChangingValue _spawnTime;
    [SerializeField] private ChangingValue _enemySpeed;
    
    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _maxScale = 5f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
        _spawnTime.Initialize();
        _enemySpeed.Initialize();
        GameCore.onEndGame += OnEndGame;
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime.currentValue);
            
            var prefab = GetFromPool();
            var enemy = _poolDictionary[prefab];
            var scale = Random.Range(_minScale, _maxScale);

            var randomPos = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * _spawnRadius;
            enemy.transform.position = randomPos;
            enemy.transform.localScale = new Vector3(scale, scale, 1);
            enemy.StartMove(((Vector2)enemy.transform.position - GameCore.shipPosition).normalized * -_enemySpeed.currentValue);

            _spawnTime.UpdateValue();
            _enemySpeed.UpdateValue();
        } 
    }

    private void OnEndGame()
    {
        GameCore.onEndGame -= OnEndGame;
        StopAllCoroutines();
        Destroy(gameObject);
    }
}

[System.Serializable]
public class ChangingValue
{
    public float currentValue => _currentValue;
    
    [SerializeField] private float _baseValue;
    [SerializeField] private float _borderValue;
    [SerializeField] private float _deltaValue;

    private float _currentValue;
    private bool _isBottomBorder;

    public void Initialize()
    {
        _isBottomBorder = false;
        _currentValue = _baseValue;
        if (_baseValue > _borderValue)
            _isBottomBorder = true;
    }

    public void UpdateValue()
    {
        _currentValue += _isBottomBorder ? -_deltaValue : _deltaValue;
    }
    
}
