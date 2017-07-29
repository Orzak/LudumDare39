using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class powerControllpanel : MonoBehaviour {
    public UnityEvent onTrigger;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "Player")
        {
            onTrigger.Invoke();
            
        }
         
           
    }



}