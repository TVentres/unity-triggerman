using UnityEngine;

public class FlowerProjectile : MonoBehaviour
{
	public int lifeSpan = 2;
	public int damage = 10;
	HUDManager hudManager;

	void Start()
	{
		Destroy(gameObject, lifeSpan);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
			HUDManager hudManager = FindObjectOfType<HUDManager>();
			hudManager.TakeDamage(damage);
		}
	}	
}