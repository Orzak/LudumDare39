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
    private float radius;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (controller.fanPower != radius)
        {
            radius = controller.fanPower;
            cc.radius = radius / 5;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // onTrigger.Invoke();
            playerluft.luft = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // onTrigger.Invoke();
            playerluft.luft = -2;
        }
    }
}
