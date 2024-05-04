using UnityEngine;

public class CoinExplosion : MonoBehaviour
{
    public GameObject coinPrefab;
    public int numCoins = 10;
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public float destroyDelay = 2f;

    void Update ()
    {
        ExplodeCoins();
    }

    public void ExplodeCoins()
    {
        for (int i = 0; i < numCoins; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = coin.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Random.insideUnitSphere * explosionForce, ForceMode.Impulse);
            }
        }

        // Destroy coins after a delay
        Destroy(gameObject, destroyDelay);
    }
}