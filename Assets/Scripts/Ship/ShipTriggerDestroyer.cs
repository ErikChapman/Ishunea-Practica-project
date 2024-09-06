using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTriggerDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var enemy = GameCore.GetEnemy(col.gameObject);

        if (enemy == null) return;
        
        GameCore.EndGame("Вы проиграли!");

        Destroy(gameObject);
    }
}
