using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class powerControllpanel : MonoBehaviour {
    public UnityEvent onTrigger;
    public float fanPower = 25;
    public float lampPower = 25;
    public float powerLevel = 100000;
    public float powerGeneration = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float powerdrain = (powerGeneration - lampPower / 10 - fanPower / 5)*Time.deltaTime;
        powerLevel -= powerdrain;

		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "Player")
        {
            onTrigger.Invoke();
            
        }
         
           
    }



}