using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

	public float rotation = 0.5f;
	public AudioSource PickupAudio;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(rotation, 0, 0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			HUDManager hudManager = FindObjectOfType<HUDManager>();
			hudManager.AddCoin();
			AudioSource.PlayClipAtPoint(PickupAudio.clip, transform.position);
			Destroy(gameObject);
		}
	}

}
