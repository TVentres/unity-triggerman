using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerShoot : MonoBehaviour
{
	public Rigidbody bullet;
	public Transform firePoint;
	public float delay = 2.0f;
	public float velocity = 1000f;

	private GameObject target;
	private float delayTimer = 0.0f;
	private bool canShoot = true;
	public AudioSource ShootAudio;

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
		//Debug.Log("shooting");
		canShoot = false;
		ShootAudio.Play();
		Rigidbody bulletInstance = Instantiate(bullet, firePoint.position, Quaternion.identity);
		Vector3 direction = (targetPosition - transform.position).normalized;
		bulletInstance.AddForce(direction * velocity * Time.deltaTime, ForceMode.Impulse);
		delayTimer = 0.0f;
	}
}