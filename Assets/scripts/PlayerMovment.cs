using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovment : MonoBehaviour {


    public float moveSpeed = 5;
    Animator animator;
    private Rigidbody2D rb;



	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
	
	void FixedUpdate () {
        Vector2 pos = transform.position;
        Vector2 move = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
        rb.velocity = transform.rotation * move;

        if (animator != null)
        {
            animator.SetFloat("speed", move.magnitude);
        }
	}
}
