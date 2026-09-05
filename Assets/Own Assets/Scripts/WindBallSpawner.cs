using UnityEngine;

public class WindBallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject windBallPrefab;
    [SerializeField] private float spawnInterval = 1f;

    private BoxCollider spawnArea;

    private void Start()
    {
        spawnArea = GetComponent<BoxCollider>();

        InvokeRepeating(nameof(SpawnBall), 0f, spawnInterval);
    }

    private void SpawnBall()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        );

        Instantiate(
            windBallPrefab,
            randomPosition,
            Quaternion.identity
        );
    }
}