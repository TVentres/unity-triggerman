using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody Bullet;
    public float Velocity;

    void Start()
    {
		Bullet.AddForce(transform.forward * Velocity * Time.deltaTime, ForceMode.Impulse);
	}


	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
