using UnityEngine;

public class FlowerProjectile : MonoBehaviour
{
	public int lifeSpan = 2;

	void Start()
	{
		Destroy(gameObject, lifeSpan);
	}

	private void OnCollisionEnter(Collision collider)
	{
		if (!collider.gameObject.CompareTag("Enemy"))
		{
			Destroy(gameObject); 
		}
	}	
}