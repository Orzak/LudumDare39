using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightpoint : MonoBehaviour
{

    public PowerMainController controller;


    private Light cc;
    public float powerTORange = 5;

    private float radius;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<Light>();
    }

    void Update()
    {
        if (controller.lampPower != radius)
        {
            radius = controller.lampPower;
            cc.range = radius / powerTORange;
        }
    }


}