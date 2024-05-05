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
		//if the projectile is colliding with a player then player takes damage
		if (other.gameObject.CompareTag("Player") ) 
		{// add && GameObject.Find("Player_01").GetComponent<TakeDamageTimer>().canHit if you want i frames for flower shots
			//projectile deletes itself
			Destroy(gameObject);
			//update player health
			HUDManager hudManager = FindObjectOfType<HUDManager>();
			hudManager.TakeDamage(damage);
			//GameObject.Find("Player_01").GetComponent<TakeDamageTimer>().gotHit();// if you want i frames for flower shots 
			
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