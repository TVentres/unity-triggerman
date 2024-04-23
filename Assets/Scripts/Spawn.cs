using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public Transform Spawn4;
    // Update is called once per frame
    void Update()
    {
        bool getPermission=GameObject.Find("PlayerPlaceholder").GetComponent<Timer>().canSpawn;
        Debug.Log(getPermission);
        //Debug.Log(1);
        if (getPermission)
        {
            GameObject.Find("PlayerPlaceholder").GetComponent<Timer>().hasSpawned();
            Spawning();
        }
    }

    public void Spawning()
    {
        int ranNum=Mathf.RoundToInt(Random.Range(1,5));
        Debug.Log(ranNum);
        Transform plane;
        if(ranNum==1)
            plane=Spawn1;
        else if(ranNum==2)
            plane=Spawn2;
        else if(ranNum==3)
            plane=Spawn3;
        else
            plane=Spawn4;

        // Spawn the object as a child of the plane.
        GameObject obj = Instantiate(enemy, Vector3.zero, Quaternion.identity, plane) as GameObject;

        //Place object in center of plain
        obj.transform.position = new Vector3(plane.position.x, 3, plane.position.z);

        // Now unassign the parent
        obj.transform.parent = null;
    }
}
