using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {
    public GameObject end;
    public GameObject player;
    public GameObject end2;
    private Vector3 pos;
    
	// Use this for initialization
	void Start () {
        pos = end.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
       Vector2 riktning = -player.transform.position + pos;
       float angle = Mathf.Atan2(riktning.y, riktning.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void level2()
    {
        pos = end2.transform.position;
    }


}
