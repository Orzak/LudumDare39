using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public PlayerMovment pM;
    public float ySpawn;
    public float xSpawn;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		 if(pM.enemyAmount > 0)
        {
            pM.enemyAmount -= 1;
            Spawnenemy();
        }
	}
    public void Spawnenemy()
    {
        Instantiate(enemy, new Vector2(transform.position.x + xSpawn, transform.position.y + ySpawn), Quaternion.identity);
    }
}
