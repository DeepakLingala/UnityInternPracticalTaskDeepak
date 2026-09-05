using UnityEngine;

public class WindBall : MonoBehaviour
{
    [Header("Random Movement")]
    [SerializeField] private float randomForce = 5f;

    [Header("Wind")]
    [SerializeField] private float windForce = 2f;

    private Rigidbody rb;
    private DynamicWindController windController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        windController = FindFirstObjectByType<DynamicWindController>();

        float randomX = Random.Range(-randomForce, randomForce);
        float randomZ = Random.Range(-randomForce, randomForce);

        Vector3 randomDirection = new Vector3(
            randomX,
            0f,
            randomZ
        );

        rb.AddForce(randomDirection, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (windController == null)
            return;

        float windStrength = windController.GetWindStrength();

        Vector3 windDirection = new Vector3(1f, 0f, 0f);

        rb.AddForce(
            windDirection * windStrength * windForce,
            ForceMode.Force
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Terrain>() != null)
        {
            Destroy(gameObject);
        }
    }
}