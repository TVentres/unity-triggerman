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
		
 		// Check if the object the player projectile collided with has the "enemy" tag.
 		if (other.gameObject.CompareTag("Enemy"))
        {
 			//Call EnemyDeath Script
			Debug.Log("This Ran");
            other.gameObject.GetComponent<EnemyDeath>().Die();
        }
		Destroy(gameObject);
    }
}
