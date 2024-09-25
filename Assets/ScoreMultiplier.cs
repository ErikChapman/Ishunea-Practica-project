using System.Collections;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    public float multiplier = 2f;
    public float duration = 5f;

    private HitCounter hitCounter;

    void Start()
    {
        hitCounter = HitCounter.instance; // Получаем доступ к счётчику
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateMultiplier());
            Destroy(gameObject);
        }
    }

    private IEnumerator ActivateMultiplier()
    {
        hitCounter.scoreMultiplier = multiplier;

        yield return new WaitForSeconds(duration);

        hitCounter.scoreMultiplier = 1f;
    }
}
