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
        if (controller != null && collision.gameObject.tag == "Player")
        {
            controller.powerGeneration += powerGeneration;
            onTrigger.Invoke();
            Generate();



        }
        if (kill == null && collision.gameObject.tag == "Player")
        {
            onTrigger.Invoke();
        }
        if (kill != null && collision.gameObject.tag == "Player") 
        {
            string on = collision.gameObject.tag; 



            StartCoroutine(Despawn(time,on));

        }
    }

    IEnumerator Despawn(float time,string on)
    {
        yield return new WaitForSeconds(time);

    
        if (on == "Player")
        {
            onTrigger.Invoke();
        }
        kill.SetActive(false);
    }


    public void Generate()
    {
        StartCoroutine(Move(time));
    }
    IEnumerator Move(float time)
    {
        while (true)
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, transform.position.z);
            yield return new WaitForSeconds(time);
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y - 0.1f, transform.position.z);
        }
    }

}

