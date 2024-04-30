using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject item1;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Die()
    {
        GameObject obj = Instantiate(item1, Vector3.zero, Quaternion.identity, transform) as GameObject;
        
        obj.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        // Now unassign the parent
        obj.transform.parent = null;
        Destroy(gameObject);
        Destroy(this.transform.parent.gameObject);
    }
}