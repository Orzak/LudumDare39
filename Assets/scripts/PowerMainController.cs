using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class PowerMainController : MonoBehaviour {

    public float fanPower = 25;
    public float lampPower = 25;
    public float powerLevel = 100000;
    public float powerGeneration = 0;
    public float maxPower = 100000;

    public GameObject ui;
    public Slider fanlevel;
    public Slider lamplevel;
    public Slider powerstatus;
    public Slider powerstatus2;

    public float powerDrainLevel= 10;

    // Use this for initialization
    void Start()
    {
        powerstatus.maxValue = maxPower;
        powerstatus2.maxValue = maxPower;
        
    }

    // Update is called once per frame
    void Update()
    {



        powerstatus.value = powerLevel;
        powerstatus2.value = powerLevel;
        float powerdrain = (powerGeneration - (lampPower / powerDrainLevel/4) - (fanPower / (powerDrainLevel/2))) * Time.deltaTime;
        powerLevel += powerdrain;
        /*Debug.Log(fanPower);
        Debug.Log(lampPower);
        Debug.Log(powerLevel);*/


        

    }


    public void OpenUI()
    {
        ui.SetActive(true);
        fanlevel.onValueChanged.RemoveAllListeners();
        fanlevel.value = fanPower;
        fanlevel.onValueChanged.AddListener(v => fanPower = v);
        lamplevel.onValueChanged.RemoveAllListeners();
        lamplevel.value = lampPower;
        lamplevel.onValueChanged.AddListener(v => lampPower = v);
    }
}
