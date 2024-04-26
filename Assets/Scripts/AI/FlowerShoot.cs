using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerShoot : MonoBehaviour
{
	public Rigidbody bulletPrefab;
	public Transform firePoint;
	public float delay = 1.0f;
	public float velocity = 1000f;

	private GameObject target;
	private float delayTimer = 0.0f;
	private bool canShoot = true;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		Vector3 targetPosition = target.transform.position;

		if (Physics.Linecast(transform.position, targetPosition) && canShoot)
		{
			delayTimer += Time.deltaTime;

			if (delayTimer >= delay)
			{
				Shoot(targetPosition);
			}
		}
		else
		{
			canShoot = true;
		}

	}

	void Shoot(Vector3 targetPosition)
	{
		Rigidbody bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

		Vector3 direction = (targetPosition - transform.position).normalized;

		bulletInstance.AddForce(direction * velocity * Time.deltaTime, ForceMode.Impulse);

		delayTimer = 0.0f;

		canShoot = false;
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collision detected!"); 
		if (collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("Destroying projectile!"); 
			Destroy(gameObject);
		}
	}

}