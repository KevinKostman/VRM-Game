using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExpSld : MonoBehaviour
{

    public GameObject playa;
    private Status status;
    public Slider expSlider;
    public float zero = 0f;
    public float maxExp = 100f;
    public float currentExp;
    
    // Start is called before the first frame update
    void Start()
    {
        status = playa.GetComponent<Status>();
        maxExp = 100f;
        currentExp = status.exp;
        expSlider.maxValue = maxExp;
        expSlider.value = currentExp;
    }

    // Update is called once per frame
    void Update()
    {
        expSlider.value = (currentExp*100)/maxExp;
        currentExp = status.exp;
        if (currentExp >= maxExp)
        {
            float rest = currentExp - maxExp;
            status.exp = rest;
            
            maxExp = MathF.Round(maxExp * 1.25f);

            status.lvl += 1;
            
        }

    }

}
