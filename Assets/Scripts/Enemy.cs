using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private int hitPoints = 10;
    [SerializeField] private int destroyScore = 100;
    [SerializeField] private int hitScore = 100;
    [SerializeField] private ScoreBoard scoreboard;
    private void Start()
    {
        scoreboard = FindFirstObjectByType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        ProccessHit(other);
        scoreboard.AddScore(hitScore);
    }
    private void ProccessHit(GameObject other)
    {
        if (hitPoints <= 0)
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreboard.AddScore(destroyScore);
        }
    }
}
