using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectCollect : MonoBehaviour {

    public UnityEvent onTrigger;
    public GameObject kill;
    public float time = 0;
    public PowerMainController controller;
    public float powerGeneration= 5;
    
    void Start () {
		
	}
	
	
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (controller != null)
        {
            controller.powerGeneration += 5;



        }

        onTrigger.Invoke();
        if (kill != null)
        {


            
            StartCoroutine(Despawn(time));

        }
    }

    IEnumerator Despawn(float time)
    {
        yield return new WaitForSeconds(time);
        kill.SetActive(false);
    }


    public void Generate()
    {
        StartCoroutine(Move(time));
    }
    IEnumerator Move(float time)
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z); 
        yield return new WaitForSeconds(time);
        transform.position = new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z);
    }
    

}

