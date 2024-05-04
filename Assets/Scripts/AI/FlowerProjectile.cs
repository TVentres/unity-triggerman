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
		if (other.gameObject.CompareTag("Player") && GameObject.Find("Player_01").GetComponent<TakeDamageTimer>().canHit)
		{
			Destroy(gameObject);

			HUDManager hudManager = FindObjectOfType<HUDManager>();
			hudManager.TakeDamage(damage);
			GameObject.Find("Player_01").GetComponent<TakeDamageTimer>().gotHit();
			
			//Debug.Log("Player Hit! Destroying game object.");

		}
		else if (!other.gameObject.CompareTag("Enemy"))
		{
			Destroy(gameObject);
			//Debug.Log("Object Hit! Destroying game object.");
		}
		Destroy(gameObject);
	}
}