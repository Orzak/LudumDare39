using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {
    public float friendAmount=2;
    float findFriends;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DeadFriend()
    {
        findFriends += 1;
    }

    public void lostFriend()
    {
        findFriends += 1;
    }



}

