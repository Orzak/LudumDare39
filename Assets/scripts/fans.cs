using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fans : MonoBehaviour
{

    public PowerMainController controller;
    public PlayerMovment playerluft;

    public GameObject kill;

    public AudioSource aS;
    private UnityEvent onTrigger;
    private bool playerInside = false;
    private bool hasAir = false;

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        if (controller.powerLevel< 0)
        {
            playerluft.luft = 2;
            hasAir = false;
            kill.SetActive(false);


        }
        if(playerInside)
        {
            aS.maxDistance = (controller.fanPower / (controller.powerDrainLevel / 2));
            if (Vector3.Distance(playerluft.transform.position, transform.position) < controller.fanPower/ (controller.powerDrainLevel/2))
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
