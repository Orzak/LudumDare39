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
    public float luftIn = 10;
    public float luftUt = 5;
    public Slider luftUI;
    public PowerMainController controller;
    public GameObject map;
    public GameObject startUI;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        luftLevel = maxLuft;
    }
	
	void FixedUpdate () {
        if (Input.GetButton("Fire3"))
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }
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
                luftLevel += (controller.fanPower/luftIn)*Time.deltaTime;
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
    public void hard()
    {
        maxLuft = 100;
        luftIn = 10;
        luftUt = 5;
        controller.maxPower = 100000;
        controller.powerDrainLevel = 10;
        luftLevel = maxLuft;
        controller.powerstatus.maxValue = controller.maxPower;
        controller.powerstatus2.maxValue = controller.maxPower;
        controller.powerLevel = controller.maxPower;
        startUI.SetActive(false);
    }
    public void Medium()
    {
        maxLuft = 100;
        luftIn = 10;
        luftUt = 2.5f;
        controller.maxPower = 500000;
        controller.powerDrainLevel = 10;
        luftLevel = maxLuft;
        controller.powerstatus.maxValue = controller.maxPower;
        controller.powerstatus2.maxValue = controller.maxPower;
        controller.powerLevel = controller.maxPower;
        startUI.SetActive(false);
    }
    public void Easy()
    {
        maxLuft = 100;
        luftIn = 15;
        luftUt = 1.7f;
        controller.maxPower = 1000000;
        controller.powerDrainLevel = 10;
        luftLevel = maxLuft;
        controller.powerstatus.maxValue = controller.maxPower;
        controller.powerstatus2.maxValue = controller.maxPower;
        controller.powerLevel = controller.maxPower;
        startUI.SetActive(false);
    }
}
