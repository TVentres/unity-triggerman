using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
	//public GameObject enemy;
	public GameObject obj_slug;
	public GameObject obj_flower;
	HUDManager hudManager;
	public AudioSource WaveChangeAudio;

	//a list of spawn locations (These will be behind the spawn doors)
	public Transform[] spawnPlanes = new Transform[2];

	public int currentWave = 0;
	public int totalWaves = 5;

	//Next few arrays keep track of how many enemies will be in each wave. ie eslugCountPerWave[0] gives the number of slugs for wave 0
	public int[] slugCountPerWave = { 0, 3, 6, 9, 12 };
	public int[] flowerCountPerWave = { 1, 2, 3, 5, 8 };

	void Start()
	{
		hudManager = FindObjectOfType<HUDManager>();
		UpdateWaveText();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (currentWave < totalWaves)
			{
				//Spawning();
				SpawnWave();
			}
		}
	}

	public void SpawnWave()
	{
		if (currentWave < totalWaves)
		{
			for (int i = 0; i < flowerCountPerWave[currentWave]; i++)
			{
				SpawnEnemy(obj_slug);
			}

			for (int i = 0; i < flowerCountPerWave[currentWave]; i++)
			{
				SpawnEnemy(obj_flower);
			}

			currentWave++;
			WaveChangeAudio.Play();
			UpdateWaveText();
		}
	}

	//spawns enemy of givem type in a random location
	public void SpawnEnemy(GameObject enemyObj)
	{
		//select a random plane from the available planes in the spawnPlanes array
		Transform plane = spawnPlanes[UnityEngine.Random.Range(0, spawnPlanes.Length)];



		//get collider for the spawnPlane
		Collider spawnCollider = plane.GetComponent<Collider>();
		//find a random x and z position in that plane
		float randX = UnityEngine.Random.Range(-spawnCollider.bounds.extents.x, spawnCollider.bounds.extents.x);
		float randZ = UnityEngine.Random.Range(-spawnCollider.bounds.extents.z, spawnCollider.bounds.extents.z);

		//Spawn game object
		GameObject obj = Instantiate(enemyObj) as GameObject;
		//Move spawned object to the random spot on the plane.
		obj.transform.position = new Vector3((plane.position.x + randX), 3, (plane.position.z + randZ));

	}

	void UpdateWaveText()
	{
		hudManager.UpdateWaveText(currentWave, totalWaves);
	}

}
