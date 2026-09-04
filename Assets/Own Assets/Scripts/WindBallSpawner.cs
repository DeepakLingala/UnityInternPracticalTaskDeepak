using UnityEngine;

public class WindBallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject windBallPrefab;
    [SerializeField] private float spawnInterval = 1f;

    [Header("Random Spawn Area")]
    [SerializeField] private float spawnAreaX = 10f;
    [SerializeField] private float spawnAreaZ = 10f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBall), 0f, spawnInterval);
    }

    private void SpawnBall()
    {
        float randomX = Random.Range(-spawnAreaX, spawnAreaX);
        float randomZ = Random.Range(-spawnAreaZ, spawnAreaZ);

        Vector3 spawnPosition = transform.position + new Vector3(
            randomX,
            0f,
            randomZ
        );

        Instantiate(
            windBallPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}