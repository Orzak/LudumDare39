using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Objective : MonoBehaviour {
    public float friendAmount=3;
    public float genetatorAmount = 1;
    float findFriends;
    float findGeneratot;
    public GameObject uiText;
    public float time = 0;
    public PowerMainController controller;
    public UnityEngine.UI.Text text;
    public UnityEvent ontrigger;
    public UnityEvent ontrigger2;
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
    public void generator()
    {
        findGeneratot += 1;
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
                text.text = string.Format(" Energy Level \n {3}/{2} \n Miners found \n {0}/{1} \n Generators found \n {4}/{5}", friendAmount, findFriends, controller.powerLevel,controller.maxPower, genetatorAmount,findGeneratot);
            }
        }
        ontrigger.Invoke();
        yield return new WaitForSeconds(time);
        
        uiText.SetActive(false);

    }
    public void End2()
    {
        StartCoroutine(Slutreal(time));
    }
    IEnumerator Slutreal(float time)
    {
        if (uiText != null)
        {
            uiText.SetActive(true);
            if (text != null)
            {
                text.text = string.Format(" Energy Level \n {3}/{2} \n Miners found \n {0}/{1} \n Generators found \n {4}/{5}", friendAmount, findFriends, controller.powerLevel, controller.maxPower, genetatorAmount, findGeneratot);
            }
        }

        
        yield return new WaitForSeconds(time);
        ontrigger2.Invoke();
        uiText.SetActive(false);
    }
        public void level2()
    {
        genetatorAmount = 3;
        findGeneratot = 0;
        friendAmount = 1;
        findFriends = 0;
    }


}

