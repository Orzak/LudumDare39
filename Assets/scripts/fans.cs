using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fans : MonoBehaviour
{

    public PowerMainController controller;
    public PlayerMovment playerluft;

    private CircleCollider2D cc;
    private UnityEvent onTrigger;
    private bool playerInside = false;
    private bool hasAir = false;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(playerInside)
        {
            if (Vector3.Distance(playerluft.transform.position, transform.position) < controller.fanPower/5)
            {
                playerluft.luft = -2;
                hasAir = true;
            }
            else if(hasAir)
            {
                playerluft.luft = 2;
                hasAir = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // onTrigger.Invoke();
            playerluft.luft = 2;
            playerInside = false;
            hasAir = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // onTrigger.Invoke();
            playerInside = true;
        }
    }
}
