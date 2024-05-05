using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //public GameObject enemy;
    public GameObject obj_Enemy1;
    public GameObject obj_flower;
    
    HUDManager hudManager;
	public AudioSource WaveChangeAudio;

    //a list of spawn locations (These will be behind the spawn doors)
    public Transform[] spawnPlanes = new Transform[2];
    public Transform ArenaSpawnPlane;
    
    //variables for keeping track of waves
    public int currentWave=0;
    public int totalWaves=5;
	public int spawnHeight=0;
    public float timeBetweenWaves=7.0f;
    public float timer;
    public int coinCount;

    //Next few arrays keep track of how many enemies will be in each wave.
    public int[] Enemy1CountPerWave= {0, 3, 6, 9, 12};
    public int[] flowerCountPerWave = { 1, 2, 3, 5, 8 };

    void Start()
	{
		hudManager = FindObjectOfType<HUDManager>();
		UpdateWaveText();
	}

	// Update is called once per frame
	void Update()
    {
        // Update timer
        timer+=Time.deltaTime;
        // If either the time ran out or no enemies are found in scene
        if (Input.GetKeyDown(KeyCode.M) || timer >=timeBetweenWaves || !GameObject.FindWithTag("Enemy"))
        {
            //If we're not already at the last wave
            if (currentWave < totalWaves)
            {
                //Spawn a wave 
                SpawnWave();
                Debug.Log(coinCount);
            }
            else
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                //Debug.Log("Number of enemies: " + enemies.Length);

                // If all waves are cleared we give the win screen
                if (enemies.Length == 0 && currentWave == totalWaves)
                {
                    Invoke("Win", 5);
                }
            }
        }
            
    }

    // Switch to win scene
    void Win()
    {
        int CoinToKeep = coinCount;
        StaticData.ValueToKeep = CoinToKeep;
        SceneManager.LoadScene("WinScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
    // Everything that goes into one wave
	public void SpawnWave()
	{
		if (currentWave < totalWaves)
		{
            Debug.Log($"Spawning wave {currentWave}");
			for (int i = 0; i < Enemy1CountPerWave[currentWave]; i++)
			{
				SpawnEnemy(obj_Enemy1);
			}

			for (int i = 0; i < flowerCountPerWave[currentWave]; i++)
			{
				SpawnCenter(obj_flower);
			}

			currentWave++;
			WaveChangeAudio.Play();
			UpdateWaveText();
            timer=0.0f;
		}
	}
	
    //spawns enemy of givem type in the arena
    public void SpawnCenter(GameObject enemyObj)
    {
        //select plane
        Transform plane = ArenaSpawnPlane;
        //get collider for the spawnPlane
        Collider spawnCollider = plane.GetComponent<Collider>();
        //find a random x and z position in that plane
        float randX = UnityEngine.Random.Range( -spawnCollider.bounds.extents.x , spawnCollider.bounds.extents.x );
        float randZ = UnityEngine.Random.Range( -spawnCollider.bounds.extents.z , spawnCollider.bounds.extents.z );

        //Spawn game object
        GameObject obj = Instantiate(enemyObj) as GameObject;
        //Move spawned object to the random spot on the plane.
        obj.transform.position = new Vector3((plane.position.x +randX), 3+spawnHeight, (plane.position.z +randZ));

    }

    //spawns enemy of givem type in a random location
    public void SpawnEnemy(GameObject enemyObj)
    {
        //select a random plane from the available planes in the spawnPlanes array
        Transform plane = spawnPlanes[UnityEngine.Random.Range(0,spawnPlanes.Length)];
        
        //get collider for the spawnPlane
        Collider spawnCollider = plane.GetComponent<Collider>();
        //find a random x and z position in that plane
        float randX = UnityEngine.Random.Range( -spawnCollider.bounds.extents.x , spawnCollider.bounds.extents.x );
        float randZ = UnityEngine.Random.Range( -spawnCollider.bounds.extents.z , spawnCollider.bounds.extents.z );

        //Spawn game object
        GameObject obj = Instantiate(enemyObj) as GameObject;
        //Move spawned object to the random spot on the plane.
        obj.transform.position = new Vector3((plane.position.x +randX), 1+spawnHeight, (plane.position.z +randZ));
    }

	void UpdateWaveText()
	{
		hudManager.UpdateWaveText(currentWave, totalWaves);
	}

}
