using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectCollect : MonoBehaviour {

    public UnityEvent onTrigger;
    public GameObject ui;
    public float time = 0;

    void Start () {
		
	}
	
	
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTrigger.Invoke();
        if (ui != null)
        {


            
            StartCoroutine(Despawn(time));

        }
    }

    IEnumerator Despawn(float time)
    {
        yield return new WaitForSeconds(time);
        ui.SetActive(false);
    }
}
