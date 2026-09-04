using UnityEngine;

public class WindBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Terrain>() != null)
        {
            Destroy(gameObject);
        }
    }
}