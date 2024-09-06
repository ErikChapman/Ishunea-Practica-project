using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameCore
{
    public static Action onEndGame;
    
    private static Dictionary<GameObject, PooledObject> _enemies = new Dictionary<GameObject, PooledObject>();
    private static GameObject _ship;

    public static void SetShip(GameObject ship)
    {
        _ship = ship;
    }

    public static void AddEnemy(PooledObject enemy)
    {
        if (_enemies.ContainsValue(enemy))
            return;

        _enemies.Add(enemy.gameObject, enemy);
    }

    public static PooledObject GetEnemy(GameObject gameObject)
    {
        if (_enemies.ContainsKey(gameObject))
            return _enemies[gameObject];

        return null;
    }

    public static void EndGame(string message = null)
    {
        if (!string.IsNullOrEmpty(message))
            Debug.LogError(message);
        
        if (onEndGame != null)
            onEndGame();

        foreach (var enemy in _enemies.Values)
            enemy.ReturnToPool();

    }
    
    public static Vector2 shipPosition
    {
        get
        {
            return _ship.transform.position;
        }
    }
}
