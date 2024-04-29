using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody Bullet;
    public float Velocity;
	public int lifeSpan=2;

    void Start()
    {
		Bullet.AddForce(transform.forward * Velocity * Time.deltaTime, ForceMode.Impulse);
		Destroy(gameObject,lifeSpan);
	}


	void OnTriggerEnter(Collider other) 
    {
		Destroy(gameObject);
 		// Check if the object the player collided with has the "PickUp" tag.
 		if (other.gameObject.CompareTag("Enemy"))
        {
 			//Call EnemyDeath Script
			Debug.Log("This Ran");
            other.gameObject.GetComponent<EnemyDeath>().Die();
        }
		Destroy(gameObject);
    }
}
