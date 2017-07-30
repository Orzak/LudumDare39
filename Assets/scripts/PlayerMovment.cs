using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour {

    public UnityEvent onSuffocated;
    public float moveSpeed = 5;
    Animator animator;
    private Rigidbody2D rb;
    public float luftSkada = 10;
    public float luft;
    public float luftLevel;
    public float maxLuft = 100;
    public float luftIn = 10;
    public float luftUt = 5;
    public Slider luftUI;
    public PowerMainController controller;
    public UnityEvent onTrigger;
    public GameObject map;
    public GameObject startUI;
    public InputField maxAir;
    public InputField airIn;
    public InputField airOut;
    public InputField powerDrain;
    public InputField maxPower;
    public InputField amountEnemy;
    public float enemyAmount;
    public Transform visual;
    public GameObject level2start;
    


	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = visual.GetComponent<Animator>();
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
        Vector2 move = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
        rb.velocity = move;
        if (move.sqrMagnitude > 0.01f)
        {
            visual.rotation = Quaternion.RotateTowards(visual.rotation, Quaternion.LookRotation(Vector3.forward, move.normalized), 360*Time.deltaTime);
            //float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg - 90;
            //rb.angularVelocity = Mathf.Clamp(angle * 5, -360, 360);
        }

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
        controller.maxPower = 1000;
        controller.powerDrainLevel = 10;
        luftLevel = maxLuft;
        controller.powerstatus.maxValue = controller.maxPower;
        controller.powerstatus2.maxValue = controller.maxPower;
        controller.powerLevel = controller.maxPower;
        enemyAmount = 3;
        startUI.SetActive(false);
    }
    public void Medium()
    {
        maxLuft = 100;
        luftIn = 10;
        luftUt = 2.5f;
        controller.maxPower = 10000;
        controller.powerDrainLevel = 10;
        luftLevel = maxLuft;
        controller.powerstatus.maxValue = controller.maxPower;
        controller.powerstatus2.maxValue = controller.maxPower;
        controller.powerLevel = controller.maxPower;
        enemyAmount = 2;
        startUI.SetActive(false);
    }
    public void Easy()
    {
        maxLuft = 100;
        luftIn = 15;
        luftUt = 1.7f;
        controller.maxPower = 50000;
        controller.powerDrainLevel = 10;
        luftLevel = maxLuft;
        controller.powerstatus.maxValue = controller.maxPower;
        controller.powerstatus2.maxValue = controller.maxPower;
        controller.powerLevel = controller.maxPower;
        enemyAmount = 1;
        startUI.SetActive(false);
    }

    public void start()
    {
        float maxPowerNum = float.Parse(maxPower.text);
        float maxAirNum = float.Parse(maxAir.text);
        float airInNum = float.Parse(airIn.text);
        float airOutNum = float.Parse(airOut.text);
        float powerDrainNum = float.Parse(powerDrain.text);
        float amountEnemyNum = float.Parse(amountEnemy.text);
        maxLuft = maxAirNum;
        luftIn = airInNum;
        luftUt = airOutNum;
        luftLevel = maxLuft;
        controller.maxPower = maxPowerNum;
        controller.powerDrainLevel = powerDrainNum;
        controller.powerstatus.maxValue = controller.maxPower;
        controller.powerstatus2.maxValue = controller.maxPower;
        controller.powerLevel = controller.maxPower;
        enemyAmount = amountEnemyNum;
        startUI.SetActive(false);

        

    }
    public void levelstart (){
        luftLevel = maxLuft;
        controller.powerstatus.maxValue = controller.maxPower;
        controller.powerstatus2.maxValue = controller.maxPower;
        controller.powerLevel = controller.maxPower;
        onTrigger.Invoke();
    }
    public void start2pos()
    {
        //rb.MovePosition(level2start.transform.position);
        transform.position = level2start.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            luftLevel -= luftSkada;
        }
    }
}
