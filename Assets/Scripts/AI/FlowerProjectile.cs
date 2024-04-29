using UnityEngine;

public class FlowerProjectile : MonoBehaviour
{
	private void OnCollisionEnter(Collision collider)
	{
		if (!collider.gameObject.CompareTag("Enemy"))
		{
			Destroy(gameObject); 
		}
	}	
}