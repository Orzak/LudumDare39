using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{




    public PowerMainController controller;
    public float moveSpeed = 3;
    public float time = 3;
    public float runSpeed = 5;
    public GameObject player;
    private AudioSource aS;

    bool playerInRange = true;
    private Rigidbody2D rb;
    Vector2 target;
    float cooldown;
    float currentSpeed;
    List<Transform> lamps;


    void Start()
    {
        target = transform.position;
        cooldown = 0;
        currentSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        lamps = new List<Transform>();
    }

    void FixedUpdate()
    {
        float minD = float.PositiveInfinity;
        for (int i = 0; i < lamps.Count; i++)
        {
            Vector2 dir = (-(Vector2)lamps[i].position + (Vector2)transform.position);
            float distans = dir.magnitude;
            if (distans < (controller.lampPower / 6.6) && distans < minD)
            {
                currentSpeed = runSpeed;
                cooldown = 0;
                target = (Vector2)transform.position + dir.normalized * 4;
                minD = distans;
                //Debug.Log(cooldown);
            }
        }



        cooldown -= Time.deltaTime;
        if (cooldown > 0)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if(Vector2.Distance(transform.position, target) < 0.1f || cooldown < -1 && rb.velocity.magnitude < moveSpeed/3) {
            
            if (playerInRange)
            {
                target = (Vector2)player.transform.position;
                currentSpeed = runSpeed;
                
            }
            else
            {
                target = (Vector2)transform.position + Random.insideUnitCircle * moveSpeed * time;
                currentSpeed = moveSpeed;
            }
            cooldown = time;
            return;
        }
        
        Vector2 mousepos = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg - 90;
        rb.MoveRotation(angle);
        rb.velocity = transform.up*currentSpeed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lamp")
        {
            lamps.Remove(collision.transform);
            if (collision.gameObject.tag == "Player")
            {
                playerInRange = false;

            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lamp")
        {
            lamps.Add(collision.transform);

        }
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;

        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;

        }
    }


}
