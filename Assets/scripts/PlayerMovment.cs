﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour {

    public UnityEvent onSuffocated;
    public float moveSpeed = 5;
    Animator animator;
    private Rigidbody2D rb;
    public float luft;
    public float luftLevel;
    public float maxLuft = 100;
    public float luftIn = 5;
    public float luftUt = 5;
    public Slider luftUI;


	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        luftLevel = maxLuft;
    }
	
	void FixedUpdate () {
        Vector2 pos = transform.position;
        Vector2 move = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
        rb.velocity = transform.rotation * move;

        luftUI.value = luftLevel;

        if (animator != null)
        {
            animator.SetFloat("speed", move.magnitude);
        }

        

        if (luft < 0)
        {
            if (luftLevel < maxLuft)
            {
                luftLevel += luftIn*Time.deltaTime;
            }
        }
        if(luft > 0)
        {
            luftLevel -= luftUt*Time.deltaTime;
            if(luftLevel < 0) {
                onSuffocated.Invoke();
            }
        }

    }


}
