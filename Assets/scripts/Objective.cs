using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Objective : MonoBehaviour {
    public float friendAmount=2;
    float findFriends;
    public GameObject uiText;
    public float time = 0;
    public PowerMainController controller;
    public UnityEngine.UI.Text text;
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
    public void End()
    {
        StartCoroutine(Slut(time));
    }
    IEnumerator Slut(float time)
    {
        if (uiText != null)
        {
            uiText.SetActive(true);
            if (text != null)
            {
                text.text = "Energy Level /n controller.powerLevel /n  Mainers found /n friendAmount/findFriends /n";
            }
        }

        yield return new WaitForSeconds(time);



    }



}

